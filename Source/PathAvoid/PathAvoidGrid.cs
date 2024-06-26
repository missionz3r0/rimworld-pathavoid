﻿using System;
using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace PathAvoid
{
    public class PathAvoidGrid : MapComponent
    {
        private class PathAvoidLevel : Verse.ICellBoolGiver
        {
            private PathAvoidGrid grid;

            private Color color;

            private byte level;

            public Color Color
            {
                get
                {
                    return this.color;
                }
            }

            public void Initialize(PathAvoidGrid grid, byte level, Color color)
            {
                this.grid = grid;
                this.level = level;
                this.color = color;
            }

            public bool GetCellBool(int index)
            {
                return this.grid.grid[index] == this.level;
            }

            public Color GetCellExtraColor(int index)
            {
                return Color.white;
            }
        }

        private static IDictionary<int, PathAvoidGrid> gridsByMap = new Dictionary<int, PathAvoidGrid>();

        private ByteGrid grid;

        private List<CellBoolDrawer> LevelDrawers;

        private bool drawMarked;

        public PathAvoidGrid(Map map) : base(map)
        {
            byte baseGridValue = SettingsController.GetBaseGridValue();

            this.grid = new ByteGrid(map);
            for (int i = 0; i < map.cellIndices.NumGridCells; i++)
            {
                this.grid[i] = baseGridValue;
            }

            drawMarked = false;
        }

        public override void ExposeData()
        {
            this.grid.ExposeData();
            if (Scribe.mode == LoadSaveMode.LoadingVars)
            {
                List<byte> list = new List<byte>();
                foreach (PathAvoidDef current in DefDatabase<PathAvoidDef>.AllDefs)
                {
                    list.Add((byte)current.level);
                }
                for (int i = 0; i < this.map.cellIndices.NumGridCells; i++)
                {
                    if (!list.Contains(this.grid[i]))
                    {
                        byte b = list[0];
                        int num = Math.Abs(b - this.grid[i]);
                        foreach (byte current2 in list)
                        {
                            if (Math.Abs(current2 - this.grid[i]) < num)
                            {
                                b = current2;
                                num = Math.Abs(b - this.grid[i]);
                            }
                        }
                        this.grid[i] = b;
                    }
                }
            }
        }

        public void MarkForDraw()
        {
            this.drawMarked = true;
        }

        public override void MapComponentUpdate()
        {
            if (this.drawMarked)
            {
                if (this.LevelDrawers == null)
                {
                    this.BuildLevelDrawers();
                }
                foreach (CellBoolDrawer current in this.LevelDrawers)
                {
                    current.MarkForDraw();
                    current.CellBoolDrawerUpdate();
                }
                this.drawMarked = false;
            }
        }

        public void BuildLevelDrawers()
        {
            this.LevelDrawers = new List<CellBoolDrawer>();
            foreach (PathAvoidDef current in DefDatabase<PathAvoidDef>.AllDefsListForReading)
            {
                var p = new PathAvoidGrid.PathAvoidLevel();
                p.Initialize(this, (byte)current.level, current.color);
                CellBoolDrawer item = new CellBoolDrawer(p, this.map.Size.x, this.map.Size.z);
                this.LevelDrawers.Add(item);
            }
        }

        public void SetValue(IntVec3 pos, byte val)
        {
            this.grid[pos] = val;
            bool flag = this.LevelDrawers != null;
            if (flag)
            {
                foreach (CellBoolDrawer current in this.LevelDrawers)
                {
                    current.SetDirty();
                }
            }
        }

        public void SetValue(int pos, byte val)
        {
            this.grid[pos] = val;
            bool flag = this.LevelDrawers != null;
            if (flag)
            {
                foreach (CellBoolDrawer current in this.LevelDrawers)
                {
                    current.SetDirty();
                }
            }
        }

        public static void ApplyAvoidGrid(Pawn p, ref ByteGrid result)
        {
            if (result == null && 
                p.Faction != null && 
                p.Faction.def.canUseAvoidGrid &&
                IsFactionFriendly(p.Faction))
            {
                Map map = p.Map;

                // Optimization: Use a cache for obtaining the avoidance grid for the current map.
                // GetComponent() is expensive unless optimized by mods such as Performance Optimizer.
                if (!gridsByMap.TryGetValue(map.uniqueID, out PathAvoidGrid pathAvoidGrid))
                {
                    pathAvoidGrid = map.GetComponent<PathAvoidGrid>();
                    if (pathAvoidGrid == null)
                    {
                        pathAvoidGrid = new PathAvoidGrid(map);
                        map.components.Add(pathAvoidGrid);
                    }
                    gridsByMap.Add(map.uniqueID, pathAvoidGrid);
                }

                result = pathAvoidGrid.grid;
            }
        }

        private static bool IsFactionFriendly(Faction f)
        {
            if (f == Faction.OfPlayer)
                return true;

            FactionRelationKind kind = f.RelationWith(Faction.OfPlayer, false).kind;
            return kind != FactionRelationKind.Hostile;
        }
    }
}

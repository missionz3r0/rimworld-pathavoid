using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace PathAvoid
{
    public class Designator_PathAvoid: Designator
    {
        public override bool DragDrawMeasurements => true;
        public override Color IconDrawColor => this.def.colorOfIcon;
        public override int DraggableDimensions => 2;
        public override string Desc => this.def.desc;
        public override string Label => this.def.name;

        protected PathAvoidDef def;

        protected void Initialize(PathAvoidDef def)
        {
            icon = ContentFinder<Texture2D>.Get("UI/Designators/PathAvoid", true);
            useMouseIcon = true;
            soundDragSustain = SoundDefOf.Designate_DragStandard;
            soundDragChanged = SoundDefOf.Designate_DragStandard_Changed;

            this.def = def;
        }

        public override AcceptanceReport CanDesignateCell(IntVec3 loc)
        {
            if (!loc.InBounds(Map))
                return false;

            return true;
        }

        public override void DesignateSingleCell(IntVec3 c)
        {
            PathAvoidGrid pathAvoidGrid = Map.GetComponent<PathAvoidGrid>();

            if (pathAvoidGrid == null)
            {
                pathAvoidGrid = new PathAvoidGrid(Map);
                Map.components.Add(pathAvoidGrid);
            }

            pathAvoidGrid.SetValue(c, (byte)this.def.level);
        }

        public override void SelectedUpdate()
        {
            GenUI.RenderMouseoverBracket();
            PathAvoidGrid pathAvoidGrid = Map.GetComponent<PathAvoidGrid>();

            if (pathAvoidGrid == null)
            {
                pathAvoidGrid = new PathAvoidGrid(Map);
                Map.components.Add(pathAvoidGrid);
            }

            pathAvoidGrid.MarkForDraw();
        }

        public override void RenderHighlight(List<IntVec3> dragCells)
        {
            DesignatorUtility.RenderHighlightOverSelectableCells(this, dragCells);
        }
    }
}

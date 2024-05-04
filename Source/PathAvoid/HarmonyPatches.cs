﻿using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;

namespace PathAvoid
{
    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            var harmony = new Harmony("missionz3r0.PathAvoid");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            Log.Message("Path Avoid: Adding Harmony Postfix to PawnUtility.GetAvoidGrid()");
        }
    }

    [HarmonyPatch(typeof(PawnUtility), "GetAvoidGrid")]
    static class Patch_PawnUtility_GetAvoidGrid
    {
        static void Postfix(Pawn p, ref ByteGrid __result)
        {
            PathAvoidGrid.ApplyAvoidGrid(p, ref __result);
        }
    }

    [HarmonyPatch(typeof(MapGenerator), "GenerateMap")]
    static class Patch_MapGenerator_GenerateMap
    {
        static void Prefix()
        {
            SettingsController.ApplyLevelSettings(DefDatabase<PathAvoidDef>.AllDefs);
        }
    }

    [HarmonyPatch(typeof(Map), "ExposeData")]
    static class Patch_Map_ExposeData
    {
        static void Prefix()
        {
            SettingsController.ApplyLevelSettings(DefDatabase<PathAvoidDef>.AllDefs);
        }
    }
}
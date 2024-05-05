using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace PathAvoid
{
    public class Designator_PathAvoid_Strong : Designator_PathAvoid
    {
        protected override DesignationDef Designation => DesignationDefOf_PathAvoid.PathAvoid_Strong;

        public Designator_PathAvoid_Strong()
        {
            defaultLabel = "PathAvoid.DesignatorStrong".Translate();

            colorDef = ColorDefOf.Structure_RedSubtle;
            defaultIconColor = colorDef.color;
        }
    }
}

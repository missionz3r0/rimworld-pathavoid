using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace PathAvoid
{
    public class Designator_PathAvoid_Hate : Designator_PathAvoid
    {
        private static Color orange = new Color(226, 134, 34);

        protected override DesignationDef Designation => DesignationDefOf_PathAvoid.PathAvoid_Hate;

        public Designator_PathAvoid_Hate()
        {
            defaultIconColor = orange;
            defaultLabel = "PathAvoid.DesignatorHate".Translate();
        }
    }
}

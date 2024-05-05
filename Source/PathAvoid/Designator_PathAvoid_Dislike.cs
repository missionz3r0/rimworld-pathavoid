using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace PathAvoid
{
    public class Designator_PathAvoid_Dislike : Designator_PathAvoid
    {
        protected override DesignationDef Designation => DesignationDefOf_PathAvoid.PathAvoid_Dislike;

        public Designator_PathAvoid_Dislike()
        {
            defaultIconColor = Color.yellow;
            defaultLabel = "PathAvoid.DesignatorDislike".Translate();
        }
    }
}

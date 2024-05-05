using RimWorld;
using UnityEngine;
using Verse;

namespace PathAvoid
{
    public class Designator_PathAvoid_Normal : Designator_PathAvoid
    {
        protected override DesignationDef Designation => DesignationDefOf_PathAvoid.PathAvoid_Normal;

        public Designator_PathAvoid_Normal()
        {
            defaultLabel = "PathAvoid.DesignatorNormal".Translate();

            colorDef = new ColorDef(

            );
            defaultIconColor = Color.green;
        }

        public override void DesignateSingleCell(IntVec3 c)
        {
            Map.designationManager.DesignationAt(c, Designation).Delete();
        }
    }
}

using RimWorld;
using Verse;

namespace PathAvoid
{
    public class Designator_PathAvoid_Prefer : Designator_PathAvoid
    {
        protected override DesignationDef Designation => DesignationDefOf_PathAvoid.PathAvoid_Prefer;

        public Designator_PathAvoid_Prefer()
        {
            defaultLabel = "PathAvoid.DesignatorPrefer".Translate();

            colorDef = ColorDefOf.Structure_BlueSubtle;
            defaultIconColor = colorDef.color;
        }
    }
}

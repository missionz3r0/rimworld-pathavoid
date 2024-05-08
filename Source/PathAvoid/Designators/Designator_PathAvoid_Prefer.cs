using Verse;

namespace PathAvoid
{
    public class Designator_PathAvoid_Prefer : Designator_PathAvoid
    {
        public Designator_PathAvoid_Prefer()
        {
            Initialize(DefDatabase<PathAvoidDef>.GetNamed("PathAvoidPrefer"));
        }
    }
}

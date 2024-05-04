using Verse;

namespace PathAvoid
{
    public class Designator_PathAvoid_Normal : Designator_PathAvoid
    {
        public Designator_PathAvoid_Normal()
        {
            Initialize(DefDatabase<PathAvoidDef>.GetNamed("PathAvoidNormal"));
        }
    }
}

using Verse;

namespace PathAvoid
{
    public class Designator_PathAvoid_Strong : Designator_PathAvoid
    {
        public Designator_PathAvoid_Strong()
        {
            Initialize(DefDatabase<PathAvoidDef>.GetNamed("PathAvoidStrong"));
        }
    }
}

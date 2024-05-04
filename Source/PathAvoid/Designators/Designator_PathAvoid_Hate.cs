using Verse;

namespace PathAvoid
{
    public class Designator_PathAvoid_Hate : Designator_PathAvoid
    {
        public Designator_PathAvoid_Hate()
        {
            Initialize(DefDatabase<PathAvoidDef>.GetNamed("PathAvoidHate"));
        }
    }
}

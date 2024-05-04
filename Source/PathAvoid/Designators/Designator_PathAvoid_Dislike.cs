using Verse;

namespace PathAvoid
{
    public class Designator_PathAvoid_Dislike : Designator_PathAvoid
    {
        public Designator_PathAvoid_Dislike()
        {
            Initialize(DefDatabase<PathAvoidDef>.GetNamed("PathAvoidDislike"));
        }
    }
}

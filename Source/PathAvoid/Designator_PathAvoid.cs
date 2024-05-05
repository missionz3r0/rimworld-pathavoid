using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace PathAvoid
{
    public class Designator_PathAvoid: Designator_Cells
    {
        public override bool DragDrawMeasurements => true;
        public override int DraggableDimensions => 2;
        public override ColorDef designationColorDef;

        public Designator_PathAvoid()
        {
            defaultDesc = "";
            icon = ContentFinder<Texture2D>.Get("UI/Designators/PathAvoid", true);
            soundDragChanged = SoundDefOf.Designate_DragStandard_Changed;
            soundDragSustain = SoundDefOf.Designate_DragStandard;
            useMouseIcon = true;
        }

        public override AcceptanceReport CanDesignateCell(IntVec3 loc)
        {
            if (!loc.InBounds(Map))
                return false;

            return true;
        }

        public override void DesignateSingleCell(IntVec3 c)
        {
            Map.designationManager.RemoveAllDesignationsOfDef(DesignationDefOf_PathAvoid.PathAvoid_Prefer);
            Map.designationManager.RemoveAllDesignationsOfDef(DesignationDefOf_PathAvoid.PathAvoid_Normal);
            Map.designationManager.RemoveAllDesignationsOfDef(DesignationDefOf_PathAvoid.PathAvoid_Dislike);
            Map.designationManager.RemoveAllDesignationsOfDef(DesignationDefOf_PathAvoid.PathAvoid_Hate);
            Map.designationManager.RemoveAllDesignationsOfDef(DesignationDefOf_PathAvoid.PathAvoid_Strong);
            Map.designationManager.AddDesignation(new Designation(c, Designation, null));
        }

        public override void SelectedUpdate()
        {
            GenUI.RenderMouseoverBracket();
            if (Map.IsPocketMap == false)
                GenDraw.DrawNoBuildEdgeLines();
        }
    }
}

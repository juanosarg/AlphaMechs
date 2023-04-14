using RimWorld;
using UnityEngine;
using Verse;
namespace AlphaMechs
{
    public class PlaceWorker_ShowCauseHediffAoEExpanded : PlaceWorker
    {
        public override void DrawGhost(ThingDef def, IntVec3 center, Rot4 rot, Color ghostCol, Thing thing = null)
        {
            CompProperties_CauseHediff_AoE_WithRestrictions compProperties = def.GetCompProperties<CompProperties_CauseHediff_AoE_WithRestrictions>();
            if (compProperties != null)
            {
                GenDraw.DrawRadiusRing(center, compProperties.range, Color.white);
            }
        }
    }
}

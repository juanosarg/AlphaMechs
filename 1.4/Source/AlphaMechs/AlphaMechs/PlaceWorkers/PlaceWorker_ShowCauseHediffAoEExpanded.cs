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

            CompProperties_CauseHediff_AoE_WithFaction compProperties2 = def.GetCompProperties<CompProperties_CauseHediff_AoE_WithFaction>();
            if (compProperties2 != null)
            {
                GenDraw.DrawRadiusRing(center, compProperties2.range, Color.white);
            }
        }
    }
}

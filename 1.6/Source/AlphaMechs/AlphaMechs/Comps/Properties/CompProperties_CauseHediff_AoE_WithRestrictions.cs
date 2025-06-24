using RimWorld;
using Verse;
using System.Collections.Generic;

namespace AlphaMechs
{
    public class CompProperties_CauseHediff_AoE_WithRestrictions : CompProperties
    {
        public HediffDef hediff;
        public List<HediffDef> conflictingHediffs;

        public BodyPartDef part;

        public float range;

        public bool onlyTargetMechs;

        public int checkInterval = 10;

        public SoundDef activeSound;

        public CompProperties_CauseHediff_AoE_WithRestrictions()
        {
            compClass = typeof(CompCauseHediff_AoE_WithRestrictions);
        }
    }
}
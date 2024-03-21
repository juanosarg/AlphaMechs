using System.Collections.Generic;
using RimWorld;
using Verse;
namespace AlphaMechs
{
    public class CompProperties_ResurrectMechMinor : CompProperties_AbilityEffect
    {


        public EffecterDef appliedEffecterDef;



        public CompProperties_ResurrectMechMinor()
        {
            compClass = typeof(CompResurrectMechMinor);
        }
    }
}

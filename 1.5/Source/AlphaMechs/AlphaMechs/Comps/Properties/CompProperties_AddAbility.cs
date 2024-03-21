
using RimWorld;
using Verse;
namespace AlphaMechs
{
    public class CompProperties_AddAbility : CompProperties
    {
        public AbilityDef ability;

      

        public CompProperties_AddAbility()
        {
            compClass = typeof(CompAddAbility);
        }
    }
}

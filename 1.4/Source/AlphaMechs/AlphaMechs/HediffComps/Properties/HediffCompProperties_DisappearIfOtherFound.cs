using System.Collections.Generic;
using Verse;
namespace AlphaMechs
{
    public class HediffCompProperties_DisappearIfOtherFound : HediffCompProperties
    {
        public List<HediffDef> conflictingHediffs;

        public HediffCompProperties_DisappearIfOtherFound()
        {
            compClass = typeof(HediffComp_DisappearIfOtherFound);
        }
    }
}

using System.Collections.Generic;
using Verse;
namespace AlphaMechs
{
    public class HediffCompProperties_DeleteAfterTime : HediffCompProperties
    {
        public int disappearsAfterTicks;
        public bool revertToMechanoid = false;
       

        public HediffCompProperties_DeleteAfterTime()
        {
            compClass = typeof(HediffComp_DeleteAfterTime);
        }
    }
}

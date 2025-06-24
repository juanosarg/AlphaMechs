using Verse;
using RimWorld;

namespace AlphaMechs
{
    public class CompProperties_TargetingBeamBlue : CompProperties
    {


        public int delayTicks;

        public DamageDef damage;


        public CompProperties_TargetingBeamBlue()
        {
            this.compClass = typeof(CompTargetingBeamBlue);
        }


    }
}
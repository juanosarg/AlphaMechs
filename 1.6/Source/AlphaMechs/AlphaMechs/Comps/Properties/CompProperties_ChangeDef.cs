using Verse;
using RimWorld;

namespace AlphaMechs
{
    public class CompProperties_ChangeDef : CompProperties
    {


        public PawnKindDef defToChangeTo;
        public FactionDef factionToChangeTo;


        public CompProperties_ChangeDef()
        {
            this.compClass = typeof(CompChangeDef);
        }


    }
}

using RimWorld;
using Verse;


namespace AlphaMechs
{
    [DefOf]
    public static class InternalDefOf
    {
        public static ThingDef AM_Aura;
        public static ThingDef AM_Daggersnout;
        public static ThingDef AM_Fireworm;



        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }
    }
}

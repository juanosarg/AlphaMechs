
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
        public static ThingDef AM_Goliath;
        public static ThingDef AM_Phalanx;
        public static ThingDef AM_Siegebreaker;
        public static ThingDef AM_Demolisher;



        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }
    }
}

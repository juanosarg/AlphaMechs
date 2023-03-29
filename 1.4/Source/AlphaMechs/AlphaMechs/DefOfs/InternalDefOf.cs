
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

        [MayRequireBiotech]
        public static ThingDef AM_Mech_Legate;
        [MayRequireBiotech]
        public static ThingDef AM_Apoptosis;
        [MayRequireBiotech]
        public static ThingDef AM_Infernus;
        [MayRequireBiotech]
        public static ThingDef AM_WarEmpress;
        [MayRequireBiotech]
        public static ThingDef AM_PristineStrider;
        [MayRequireBiotech]
        public static ThingDef AM_Bullet_Starfire_Secondary;

        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }
    }
}

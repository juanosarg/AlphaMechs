
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

        [MayRequire("OskarPotocki.VFE.Mechanoid")]
        public static ThingDef VFE_Mech_Aura;
        [MayRequire("OskarPotocki.VFE.Mechanoid")]
        public static ThingDef VFE_Mech_Advanced_Aura;

        [MayRequire("OskarPotocki.VFE.Mechanoid")]
        public static ThingDef VFE_Mech_Daggersnout;
        [MayRequire("OskarPotocki.VFE.Mechanoid")]
        public static ThingDef VFE_Mech_Advanced_Daggersnout;

        [MayRequire("OskarPotocki.VFE.Mechanoid")]
        public static ThingDef VFE_Mech_Fireworm;
        [MayRequire("OskarPotocki.VFE.Mechanoid")]
        public static ThingDef VFE_Mech_Advanced_Fireworm;

        [MayRequire("OskarPotocki.VFE.Mechanoid")]
        public static ThingDef VFE_Mech_Goliath;
        [MayRequire("OskarPotocki.VFE.Mechanoid")]
        public static ThingDef VFE_Mech_Advanced_Goliath;

        [MayRequire("OskarPotocki.VFE.Mechanoid")]
        public static ThingDef VFE_Mech_Phalanx;
        [MayRequire("OskarPotocki.VFE.Mechanoid")]
        public static ThingDef VFE_Mech_Advanced_Phalanx;

        [MayRequire("OskarPotocki.VFE.Mechanoid")]
        public static ThingDef VFE_Mech_Siegebreaker;
        [MayRequire("OskarPotocki.VFE.Mechanoid")]
        public static ThingDef VFE_Mech_Advanced_Siegebreaker;

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
        [MayRequireBiotech]
        public static ThingDef AM_GreaterRecharger;

        [MayRequireBiotech]
        public static ThingDef AM_GreaterBandNode;
        [MayRequireBiotech]
        public static ThingDef AM_BeamcasterBandNode;

        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }
    }
}

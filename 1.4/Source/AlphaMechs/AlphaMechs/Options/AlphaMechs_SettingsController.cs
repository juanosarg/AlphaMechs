using RimWorld;
using UnityEngine;
using Verse;
using System.Collections.Generic;
using System.Linq;

namespace AlphaMechs
{



    public class AlphaMechs_Mod : Mod
    {
        public static AlphaMechs_Settings settings;

        public AlphaMechs_Mod(ModContentPack content) : base(content)
        {
            settings = GetSettings<AlphaMechs_Settings>();
        }
        public override string SettingsCategory() => "Alpha Mechs";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            settings.DoWindowContents(inRect);
        }
    }

   
}

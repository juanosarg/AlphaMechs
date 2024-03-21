using RimWorld;
using UnityEngine;
using Verse;
using System.Collections.Generic;
using System.Linq;

namespace AlphaMechs
{



    public class AlphaMechs_Mod : Mod
    {
        

        public AlphaMechs_Mod(ModContentPack content) : base(content)
        {
            GetSettings<AlphaMechs_Settings>();
        }
        public override string SettingsCategory() => "Alpha Mechs";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            AlphaMechs_Settings.DoWindowContents(inRect);
        }
    }

   
}

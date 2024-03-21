using System.Collections.Generic;
using Verse;
using System.Linq;
using UnityEngine;
using System;



namespace AlphaMechs
{
    public class AlphaMechs_Settings : ModSettings

    {


        public static bool flagAura = true;
        public static bool flagDaggersnout = true;
        public static bool flagDemolisher = true;
        public static bool flagFireworm = true;
        public static bool flagGoliath = true;
        public static bool flagPhalanx = true;
        public static bool flagSiegebreaker = true;

        public static float tier2bandAmount = baseTier2bandAmount;
        public const float baseTier2bandAmount = 2;
        public static float tier3bandAmount = baseTier3bandAmount;
        public const float baseTier3bandAmount = 5;




        public override void ExposeData()
        {
            base.ExposeData();

  
             Scribe_Values.Look(ref flagAura, "flagAura", true, true);
             Scribe_Values.Look(ref flagDaggersnout, "flagDaggersnout", true, true);
             Scribe_Values.Look(ref flagDemolisher, "flagDemolisher", true, true);
             Scribe_Values.Look(ref flagFireworm, "flagFireworm", true, true);
             Scribe_Values.Look(ref flagGoliath, "flagGoliath", true, true);
             Scribe_Values.Look(ref flagPhalanx, "flagPhalanx", true, true);
             Scribe_Values.Look(ref flagSiegebreaker, "flagSiegebreaker", true, true);
            Scribe_Values.Look(ref tier2bandAmount, "tier2bandAmount", baseTier2bandAmount);
            Scribe_Values.Look(ref tier3bandAmount, "tier3bandAmount", baseTier3bandAmount);






        }

        public static  void DoWindowContents(Rect inRect)
        {
            Listing_Standard ls = new Listing_Standard();


            ls.Begin(inRect);
            ls.Gap(10f);


            ls.CheckboxLabeled("AM_allowAura".Translate(), ref flagAura, null);

            ls.CheckboxLabeled("AM_allowDaggersnout".Translate(), ref flagDaggersnout, null);

            ls.CheckboxLabeled("AM_allowDemolisher".Translate(), ref flagDemolisher, null);

            ls.CheckboxLabeled("AM_allowFireworm".Translate(), ref flagFireworm, null);

            ls.CheckboxLabeled("AM_allowGoliath".Translate(), ref flagGoliath, null);

            ls.CheckboxLabeled("AM_allowPhalanx".Translate(), ref flagPhalanx, null);

            ls.CheckboxLabeled("AM_allowSiegebreaker".Translate(), ref flagSiegebreaker, null);

            var tier2Label = ls.LabelPlusButton("AM_Tier2BandAmount".Translate() + ": " + tier2bandAmount, "AM_Tier2BandAmountDesc".Translate());
            tier2bandAmount = (float)Math.Round(ls.Slider(tier2bandAmount, 1, 20), 0);

            if (ls.Settings_Button("AM_Reset".Translate(), new Rect(0f, tier2Label.position.y + 35, 250f, 29f)))
            {
                tier2bandAmount = baseTier2bandAmount;
            }

            var tier3Label = ls.LabelPlusButton("AM_Tier3BandAmount".Translate() + ": " + tier3bandAmount, "AM_Tier3BandAmountDesc".Translate());
            tier3bandAmount = (float)Math.Round(ls.Slider(tier3bandAmount, 1, 20), 0);

            if (ls.Settings_Button("AM_Reset".Translate(), new Rect(0f, tier3Label.position.y + 35, 250f, 29f)))
            {
                tier3bandAmount = baseTier3bandAmount;
            }





            ls.End();
        }



    }










}

using RimWorld;
using UnityEngine;
using Verse;
using System.Collections.Generic;
using System.Linq;
using System;


namespace AlphaMechs
{
    public class AlphaMechs_Settings : ModSettings

    {
 


        public bool flagAura = true;
        public bool flagDaggersnout = true;
        public bool flagDemolisher = true;
        public bool flagFireworm = true;
        public bool flagGoliath = true;
        public bool flagPhalanx = true;
        public bool flagSiegebreaker = true;
      
      



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
           





        }

        public void DoWindowContents(Rect inRect)
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

           





            ls.End();
        }



    }










}

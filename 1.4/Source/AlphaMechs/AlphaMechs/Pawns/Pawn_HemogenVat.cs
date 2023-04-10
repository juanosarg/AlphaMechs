
using RimWorld;
using System;
using Verse;
using RimWorld.Planet;
using System.Collections.Generic;
using UnityEngine;

namespace AlphaMechs
{
    public class Pawn_HemogenVat: Pawn
    {

        public int hemogenAmount = 0;


        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref hemogenAmount, "hemogenAmount", defaultValue: 0);
        }

        public override IEnumerable<Gizmo> GetGizmos()
        {
            foreach(Gizmo gizmo in base.GetGizmos())
            {
                yield return gizmo;
            }

            if (hemogenAmount > 0)
            {
                Command_Action command_Action = new Command_Action();
                command_Action.action = delegate ()
                {
                    EjectContents();
                };
                command_Action.defaultLabel = "AM_EjectHemogen".Translate();
                command_Action.defaultDesc = "AM_EjectHemogenDesc".Translate();               
                command_Action.hotKey = KeyBindingDefOf.Misc8;
                command_Action.icon = ContentFinder<Texture2D>.Get("UI/Abilities/AM_RemoveHemogenPacks");
                yield return command_Action;
            }


        }

        public override string GetInspectString()
        {
            return base.GetInspectString()+"\n"+"AM_HemogenStored".Translate(hemogenAmount);
        }

        public void EjectContents()
        {

            Thing hemopack = ThingMaker.MakeThing(ThingDefOf.HemogenPack);
            if (!GenPlace.TryPlaceThing(hemopack, this.PositionHeld, this.MapHeld, ThingPlaceMode.Near))
            {
                Log.Error("Could not drop hemogen pack near " + this.PositionHeld);
            }
            else
            {
                hemopack.stackCount = hemogenAmount;
                hemogenAmount = 0;
            }

        }





    }
}

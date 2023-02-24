using AlphaMechs;
using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using Verse.AI.Group;

namespace AlphaMechs
{
    public class CompChangeDef : ThingComp
    {
        public int tickCounter = 0;



        public CompProperties_ChangeDef Props
        {
            get
            {
                return (CompProperties_ChangeDef)this.props;
            }
        }

        public override void CompTick()
        {
            
           
            if (tickCounter == 0)
            {
                

                
              
                if (!IsMechToggled())
                {
                    
                    if (parent.Map != null &&parent.Faction!=Faction.OfPlayer && Find.FactionManager.FirstFactionOfDef(Props.factionToChangeTo) != null)
                    {
                        PawnGenerationRequest request = new PawnGenerationRequest(Props.defToChangeTo, Find.FactionManager.FirstFactionOfDef(Props.factionToChangeTo), PawnGenerationContext.NonPlayer, -1, true, false, false, false, true);
                        Pawn pawn = PawnGenerator.GeneratePawn(request);
                        GenSpawn.Spawn(pawn, this.parent.Position, parent.Map, WipeMode.Vanish);

                        Lord lord = null;
                        if (pawn.Map.mapPawns.SpawnedPawnsInFaction(Find.FactionManager.FirstFactionOfDef(Props.factionToChangeTo)).Any((Pawn p) => p != pawn))
                        {
                            lord = ((Pawn)GenClosest.ClosestThing_Global(pawn.Position, pawn.Map.mapPawns.SpawnedPawnsInFaction(Find.FactionManager.FirstFactionOfDef(Props.factionToChangeTo)), 99999f, (Thing p) => p != pawn && ((Pawn)p).GetLord() != null, null)).GetLord();
                        }
                        if (lord == null)
                        {
                            LordJob_DefendPoint lordJob = new LordJob_DefendPoint(pawn.Position, null, false, true);
                            lord = LordMaker.MakeNewLord(Find.FactionManager.FirstFactionOfDef(Props.factionToChangeTo), lordJob, Find.CurrentMap, null);
                        }
                        lord.AddPawn(pawn);


                        this.parent.Destroy();
                    }
                }
                

                
                
            }




            tickCounter++;

            if (tickCounter > 300)
            {
                tickCounter = 0;
            }



        }

        public bool IsMechToggled()
        {
            if (parent.def == InternalDefOf.AM_Aura)
            {
                return AlphaMechs_Settings.flagAura;
            } else if (parent.def == InternalDefOf.AM_Daggersnout)
            {
                return AlphaMechs_Settings.flagDaggersnout;
            }
            else if (parent.def == InternalDefOf.AM_Fireworm)
            {
                return AlphaMechs_Settings.flagFireworm;
            }
            else if (parent.def == InternalDefOf.AM_Goliath)
            {
                return AlphaMechs_Settings.flagGoliath;
            }
            else if (parent.def == InternalDefOf.AM_Phalanx)
            {
                return AlphaMechs_Settings.flagPhalanx;
            }
            else if (parent.def == InternalDefOf.AM_Siegebreaker)
            {
                return AlphaMechs_Settings.flagSiegebreaker;
            }
            else if (parent.def == InternalDefOf.AM_Demolisher)
            {
                return AlphaMechs_Settings.flagDemolisher;
            }


            return true;


        }




    }
}
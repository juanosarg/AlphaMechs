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

        public List<ThingDef> auraList = new List<ThingDef>() { InternalDefOf.AM_Aura,InternalDefOf.VFE_Mech_Aura,InternalDefOf.VFE_Mech_Advanced_Aura};
        public List<ThingDef> daggersnoutList = new List<ThingDef>() { InternalDefOf.AM_Daggersnout, InternalDefOf.VFE_Mech_Daggersnout, InternalDefOf.VFE_Mech_Advanced_Daggersnout };
        public List<ThingDef> firewormList = new List<ThingDef>() { InternalDefOf.AM_Fireworm, InternalDefOf.VFE_Mech_Fireworm, InternalDefOf.VFE_Mech_Advanced_Fireworm };
        public List<ThingDef> goliathList = new List<ThingDef>() { InternalDefOf.AM_Goliath, InternalDefOf.VFE_Mech_Goliath, InternalDefOf.VFE_Mech_Advanced_Goliath };
        public List<ThingDef> phalanxList = new List<ThingDef>() { InternalDefOf.AM_Phalanx, InternalDefOf.VFE_Mech_Phalanx, InternalDefOf.VFE_Mech_Advanced_Phalanx };
        public List<ThingDef> siegebreakerList = new List<ThingDef>() { InternalDefOf.AM_Siegebreaker, InternalDefOf.VFE_Mech_Siegebreaker, InternalDefOf.VFE_Mech_Advanced_Siegebreaker };




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
            if (auraList.Contains(parent.def))
            {
                return AlphaMechs_Settings.flagAura;
            } else if (daggersnoutList.Contains(parent.def))
            {
                return AlphaMechs_Settings.flagDaggersnout;
            }
            else if (firewormList.Contains(parent.def))
            {
                return AlphaMechs_Settings.flagFireworm;
            }
            else if (goliathList.Contains(parent.def))
            {
                return AlphaMechs_Settings.flagGoliath;
            }
            else if (phalanxList.Contains(parent.def))
            {
                return AlphaMechs_Settings.flagPhalanx;
            }
            else if (siegebreakerList.Contains(parent.def))
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
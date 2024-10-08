﻿
using RimWorld;
using UnityEngine;
using Verse;
using Verse.Sound;
namespace AlphaMechs
{
    [StaticConstructorOnStartup]
    public class CompCauseHediff_AoE_WithRestrictions : ThingComp
    {
        private Sustainer activeSustainer;

        private bool lastIntervalActive;

        public static readonly string LineTexPath = "UI/Overlays/ThingLine";
        private static readonly Material LineMatMagenta = MaterialPool.MatFrom(LineTexPath, ShaderDatabase.Transparent, Color.magenta);

        private CompProperties_CauseHediff_AoE_WithRestrictions Props => (CompProperties_CauseHediff_AoE_WithRestrictions)props;

        private CompPowerTrader PowerTrader => parent.TryGetComp<CompPowerTrader>();

        private bool IsPawnAffected(Pawn target)
        {
            if (PowerTrader != null && !PowerTrader.PowerOn)
            {
                return false;
            }
            if (target.Dead || target.health == null)
            {
                return false;
            }
            if (target.Faction != parent.Faction)
            {
                return false;
            }
            if (target.Position.DistanceTo(parent.Position) <= Props.range)
            {
                if (Props.onlyTargetMechs)
                {
                    return target.RaceProps.IsMechanoid;
                }
                return true;
            }
            return false;
        }

        public override void CompTick()
        {
            MaintainSustainer();
            if (!parent.IsHashIntervalTick(Props.checkInterval))
            {
                return;
            }
            CompPowerTrader compPowerTrader = parent.TryGetComp<CompPowerTrader>();
            if (compPowerTrader != null && !compPowerTrader.PowerOn)
            {
                return;
            }
            lastIntervalActive = false;
            foreach (Pawn item in parent.Map.mapPawns.AllPawnsSpawned)
            {
                if (!IsPawnAffected(item))
                {
                    continue;
                }
                foreach(HediffDef conflictingHediff in Props.conflictingHediffs)
                {
                    if (item.health.hediffSet.GetFirstHediffOfDef(conflictingHediff) != null)
                    {
                        return;
                    }
                }



                Hediff hediff = item.health.hediffSet.GetFirstHediffOfDef(Props.hediff);
                if (hediff == null)
                {
                    hediff = item.health.AddHediff(Props.hediff, item.health.hediffSet.GetBrain());
                    hediff.Severity = 1f;
                    HediffComp_Link hediffComp_Link = hediff.TryGetComp<HediffComp_Link>();
                    if (hediffComp_Link != null)
                    {
                        hediffComp_Link.drawConnection = false;
                        hediffComp_Link.other = parent;
                    }
                }
                HediffComp_Disappears hediffComp_Disappears = hediff.TryGetComp<HediffComp_Disappears>();
                if (hediffComp_Disappears != null)
                {
                    hediffComp_Disappears.ticksToDisappear = Props.checkInterval + 1;
                }
               
                lastIntervalActive = true;
            }
        }

        private void MaintainSustainer()
        {
            if (lastIntervalActive && Props.activeSound != null)
            {
                if (activeSustainer == null || activeSustainer.Ended)
                {
                    activeSustainer = Props.activeSound.TrySpawnSustainer(SoundInfo.InMap(new TargetInfo(parent)));
                }
                activeSustainer.Maintain();
            }
            else if (activeSustainer != null)
            {
                activeSustainer.End();
                activeSustainer = null;
            }
        }

        public override void PostDraw()
        {
            if (!Find.Selector.SelectedObjectsListForReading.Contains(parent))
            {
                return;
            }
            foreach (Pawn item in parent.Map.mapPawns.AllPawnsSpawned)
            {
                if (IsPawnAffected(item))
                {
                    GenDraw.DrawLineBetween(item.DrawPos, parent.DrawPos, LineMatMagenta);
                }
            }
        }
    }
}
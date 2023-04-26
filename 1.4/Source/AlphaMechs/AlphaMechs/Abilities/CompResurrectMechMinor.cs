
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;
namespace AlphaMechs
{
    public class CompResurrectMechMinor : CompAbilityEffect
    {
      
       

        public new CompProperties_ResurrectMechMinor Props => (CompProperties_ResurrectMechMinor)props;



      
        public override bool CanApplyOn(LocalTargetInfo target, LocalTargetInfo dest)
        {
            if (!base.CanApplyOn(target, dest))
            {
                return false;
            }
            Corpse corpse;
            if (!target.HasThing || (corpse = target.Thing as Corpse) == null)
            {
                return false;
            }
            if (!CanResurrect(corpse))
            {
                return false;
            }
            return true;
        }

       

        private bool CanResurrect(Corpse corpse)
        {
            if (!corpse.InnerPawn.RaceProps.IsMechanoid || corpse.InnerPawn.RaceProps.mechWeightClass >= MechWeightClass.UltraHeavy)
            {
                return false;
            }
            if (corpse.InnerPawn.Faction != parent.pawn.Faction)
            {
                return false;
            }
            if (corpse.InnerPawn.kindDef.abilities != null && corpse.InnerPawn.kindDef.abilities.Contains(AbilityDefOf.ResurrectionMech))
            {
                return false;
            }
           
           
            return true;
        }

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            Corpse corpse = (Corpse)target.Thing;
            if (CanResurrect(corpse))
            {
                Pawn innerPawn = corpse.InnerPawn;
               
                ResurrectionUtility.Resurrect(innerPawn);
                if (Props.appliedEffecterDef != null)
                {
                    Effecter effecter = Props.appliedEffecterDef.SpawnAttached(innerPawn, innerPawn.MapHeld);
                    effecter.Trigger(innerPawn, innerPawn);
                    effecter.Cleanup();
                }
                innerPawn.stances.stagger.StaggerFor(60);
            }
        }

       

      

        public override IEnumerable<Mote> CustomWarmupMotes(LocalTargetInfo target)
        {
            foreach (LocalTargetInfo affectedTarget in parent.GetAffectedTargets(target))
            {
                Thing thing = affectedTarget.Thing;
                yield return MoteMaker.MakeAttachedOverlay(thing, ThingDefOf.Mote_MechResurrectWarmupOnTarget, Vector3.zero);
            }
        }

        public override void PostApplied(List<LocalTargetInfo> targets, Map map)
        {
            Vector3 zero = Vector3.zero;
            foreach (LocalTargetInfo target in targets)
            {
                zero += target.Cell.ToVector3Shifted();
            }
            zero /= (float)targets.Count();
            IntVec3 intVec = zero.ToIntVec3();
            EffecterDefOf.ApocrionAoeResolve.Spawn(intVec, map).EffectTick(new TargetInfo(intVec, map), new TargetInfo(intVec, map));
        }

       
    }
}
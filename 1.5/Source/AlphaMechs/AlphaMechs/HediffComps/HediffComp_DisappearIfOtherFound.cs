using System.Collections.Generic;
using System;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.Noise;
namespace AlphaMechs
{
    public class HediffComp_DisappearIfOtherFound : HediffComp
    {
       
        public HediffCompProperties_DisappearIfOtherFound Props => (HediffCompProperties_DisappearIfOtherFound)props;

        

        public override void CompPostTick(ref float severityAdjustment)
        {
            if (this.parent.pawn.IsHashIntervalTick(600))
            {
                foreach (HediffDef conflictingHediff in Props.conflictingHediffs)
                {
                    if (this.parent.pawn.health.hediffSet.GetFirstHediffOfDef(conflictingHediff) != null)
                    {
                        this.parent.pawn.health.RemoveHediff(parent);
                    }
                }

            }
        }

       
    }
}

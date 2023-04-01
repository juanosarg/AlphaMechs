
using System;
using System.Collections.Generic;
using RimWorld;
using Verse;
namespace AlphaMechs
{
    public class ThoughtWorker_GreaterHateAura : ThoughtWorker
    {

       

        private enum HateAuraLevel
        {
            None,
            Intense,
            Strong,
            Distant
        }

        private const float IntenseDistance = 3.9f;

        private const float StrongDistance = 8.9f;

        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            HateAuraLevel hateAuraLevel = HateAuraLevel.None;
            if (p.Map != null)
            {
                List<Thing> list = p.Map.listerThings.ThingsOfDef(InternalDefOf.AM_Apoptosis);
                list.SortBy((Thing m) => m.Position.DistanceToSquared(m.Position));
                if (list.Count > 0)
                {
                    float num = list[0].Position.DistanceTo(p.Position);
                    hateAuraLevel = ((num <= IntenseDistance) ? HateAuraLevel.Intense : ((!(num <= StrongDistance)) ? HateAuraLevel.Distant : HateAuraLevel.Strong));
                }
            }
            return hateAuraLevel switch
            {
                HateAuraLevel.None => false,
                HateAuraLevel.Intense => ThoughtState.ActiveAtStage(0),
                HateAuraLevel.Strong => ThoughtState.ActiveAtStage(1),
                HateAuraLevel.Distant => ThoughtState.ActiveAtStage(2),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
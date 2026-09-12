using RimWorld;
using Verse;

namespace AlphaMechs
{
    public class CompMechConversion : CompAbilityEffect
    {
     
        public new CompProperties_MechConversion Props => (CompProperties_MechConversion)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            Pawn mech = target.Pawn;
            if (mech != null)
            {

                int num = parent.pawn.mechanitor.TotalBandwidth - parent.pawn.mechanitor.UsedBandwidth;
                float statValue = mech.GetStatValue(StatDefOf.BandwidthCost);
                if ((float)num < statValue)
                {
                    Messages.Message("AM_NotEnoughBandwidth".Translate(mech.LabelCap), mech, MessageTypeDefOf.RejectInput, historical: false);
                    return;
                }

                mech.SetFaction(Faction.OfPlayer);
                mech.GetOverseer()?.relations.RemoveDirectRelation(PawnRelationDefOf.Overseer, mech);
                parent.pawn.relations.AddDirectRelation(PawnRelationDefOf.Overseer, mech);
                mech.health.AddHediff(InternalDefOf.AM_ScrambledIFF);
            }
        }

        public override bool CanApplyOn(LocalTargetInfo target, LocalTargetInfo dest)
        {
            return Valid(target);
        }

        public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
        {
            Pawn pawn = target.Pawn;
            if (pawn == null)
            {
                return false;
            }
            if (!pawn.RaceProps.IsMechanoid)
            {
                if (throwMessages)
                {
                    Messages.Message("AM_CantUseOnNonMechs".Translate(), pawn, MessageTypeDefOf.RejectInput, historical: false);
                }
                return false;
            }

            if (StaticCollections.blacklistedMechs.Contains(pawn.kindDef))
            {
                if (throwMessages)
                {
                    Messages.Message("AM_CantUseOnBossMechs".Translate(), pawn, MessageTypeDefOf.RejectInput, historical: false);
                }
                return false;
            }

            if (pawn.Faction?.def?.defName == "VFE_Mechanoid")
            {
                if (throwMessages)
                {
                    Messages.Message("AM_CantUseVEMechs".Translate(), pawn, MessageTypeDefOf.RejectInput, historical: false);
                }
                return false;
            }

            if (!MechanitorUtility.IsMechanitor(parent.pawn))
            {
                if (throwMessages)
                {
                    Messages.Message("AM_OnlyMechanitorCanUse".Translate(), parent.pawn, MessageTypeDefOf.RejectInput, historical: false);
                }
                return false;
            }
           
            return true;


        }

    }
}
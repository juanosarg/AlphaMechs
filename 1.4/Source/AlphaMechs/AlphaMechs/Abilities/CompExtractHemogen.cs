
using RimWorld;
using System;
using Verse;
using RimWorld.Planet;
using System.Collections.Generic;

namespace AlphaMechs
{
    public class CompExtractHemogen : CompAbilityEffect
    {
       
        public new CompProperties_AbilityExtractHemogen Props => (CompProperties_AbilityExtractHemogen)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            Pawn pawn = target.Pawn;
            if (pawn != null)
            {
                if (!PawnHasEnoughBloodForExtraction(pawn))
                {
                    Messages.Message("MessagePawnHadNotEnoughBloodToProduceHemogenPack".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.NeutralEvent);
                    return;
                }
                Hediff hediff = HediffMaker.MakeHediff(HediffDefOf.BloodLoss, pawn);
                hediff.Severity = 0.45f;
                pawn.health.AddHediff(hediff);
              
                if (IsViolationOnPawn(pawn, Faction.OfPlayer))
                {
                    ReportViolation(pawn, parent.pawn, pawn.HomeFaction, -1, HistoryEventDefOf.ExtractedHemogenPack);
                }

                Pawn_HemogenVat pawnHemogenFarm = parent.pawn as Pawn_HemogenVat;
                if (pawnHemogenFarm != null)
                {
                    pawnHemogenFarm.hemogenAmount++;
                }



            }


        }

        public virtual bool IsViolationOnPawn(Pawn pawn, Faction billDoerFaction)
        {
            if (pawn.Faction == billDoerFaction && !pawn.IsQuestLodger())
            {
                return false;
            }
            return true;
        }

        protected void ReportViolation(Pawn pawn, Pawn billDoer, Faction factionToInform, int goodwillImpact, HistoryEventDef overrideEventDef = null)
        {
            if (factionToInform != null && billDoer != null && billDoer.Faction == Faction.OfPlayer)
            {
                Faction.OfPlayer.TryAffectGoodwillWith(factionToInform, goodwillImpact, canSendMessage: true, !factionToInform.temporary, overrideEventDef ?? HistoryEventDefOf.PerformedHarmfulSurgery);
                QuestUtility.SendQuestTargetSignals(pawn.questTags, "SurgeryViolation", pawn.Named("SUBJECT"));
            }
        }


        private bool PawnHasEnoughBloodForExtraction(Pawn pawn)
        {
            Hediff firstHediffOfDef = pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.BloodLoss);
            if (firstHediffOfDef != null)
            {
                return firstHediffOfDef.Severity < 0.45f;
            }
            return true;
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
            if (!AbilityUtility.ValidateMustBeHumanOrWildMan(pawn, throwMessages, parent))
            {
                return false;
            }
                        
            if (!pawn.Downed && !pawn.InBed())
            {
                if (throwMessages)
                {
                    Messages.Message("AM_CantUseOnNonDowned".Translate(), pawn, MessageTypeDefOf.RejectInput, historical: false);
                }
                return false;
            }
            return true;


        }

        public override string ExtraLabelMouseAttachment(LocalTargetInfo target)
        {
            Pawn pawn = target.Pawn;
            if (pawn != null)
            {
                string text = null;

                float num = BloodlossAfterBite(pawn);
                if (num >= HediffDefOf.BloodLoss.lethalSeverity)
                {
                    if (!text.NullOrEmpty())
                    {
                        text += "\n";
                    }
                    text += "WillKill".Translate();
                }
                else if (HediffDefOf.BloodLoss.stages[HediffDefOf.BloodLoss.StageAtSeverity(num)].lifeThreatening)
                {
                    if (!text.NullOrEmpty())
                    {
                        text += "\n";
                    }
                    text += "WillCauseSeriousBloodloss".Translate();
                }
                return text;
            }
            return base.ExtraLabelMouseAttachment(target);
        }

        public override Window ConfirmationDialog(LocalTargetInfo target, Action confirmAction)
        {
            Pawn pawn = target.Pawn;
            if (pawn != null)
            {
                float num = BloodlossAfterBite(pawn);

                if (HediffDefOf.BloodLoss.stages[HediffDefOf.BloodLoss.StageAtSeverity(num)].lifeThreatening)
                {
                    return Dialog_MessageBox.CreateConfirmation("WarningPawnWillHaveSeriousBloodlossFromBloodfeeding".Translate(pawn.Named("PAWN")), confirmAction, destructive: true);
                }
            }
            return null;
        }

        private float BloodlossAfterBite(Pawn target)
        {
            if (target.Dead || !target.RaceProps.IsFlesh)
            {
                return 0f;
            }
            float num = 0.45f;
            Hediff firstHediffOfDef = target.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.BloodLoss);
            if (firstHediffOfDef != null)
            {
                num += firstHediffOfDef.Severity;
            }
            return num;
        }



    }
}
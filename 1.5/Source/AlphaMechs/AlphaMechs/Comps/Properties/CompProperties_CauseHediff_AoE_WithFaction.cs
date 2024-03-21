
using RimWorld;
using Verse;
namespace AlphaMechs
{
	public class CompProperties_CauseHediff_AoE_WithFaction : CompProperties
	{
		public HediffDef hediff;

		public BodyPartDef part;

		public float range;

		public bool onlyTargetMechs;

		public int checkInterval = 10;

		public SoundDef activeSound;

		public bool affectMyFaction = true;

		public CompProperties_CauseHediff_AoE_WithFaction()
		{
			compClass = typeof(CompCauseHediff_AoE_WithFaction);
		}
	}
}

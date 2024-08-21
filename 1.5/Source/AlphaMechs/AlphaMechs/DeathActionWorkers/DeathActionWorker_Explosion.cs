using RimWorld;
using Verse;
using Verse.AI.Group;

namespace AlphaMechs
{
	public class DeathActionWorker_Explosion : DeathActionWorker
	{

        public DeathActionProperties_Explosion Props => (DeathActionProperties_Explosion)props;

        public override RulePackDef DeathRules => RulePackDefOf.Transition_DiedExplosive;

		public override bool DangerousInMelee => true;

		public override void PawnDied(Corpse corpse, Lord prevLord)
		{
			GenExplosion.DoExplosion(radius: Props.radius, center: corpse.Position, map: corpse.Map, damType: Props.damType,
				damAmount:Props.damAmount,chanceToStartFire:Props.chanceToStartFire,instigator: corpse.InnerPawn, explosionSound: Props.sound, 
				postExplosionSpawnThingDef: Props.postExplosionSpawnThingDef, postExplosionSpawnChance: Props.postExplosionSpawnChance);
		}
	}
}

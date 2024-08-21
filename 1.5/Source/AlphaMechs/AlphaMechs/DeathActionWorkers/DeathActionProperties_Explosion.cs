
using System;
using System.Collections.Generic;
using Verse;
namespace AlphaMechs
{
    public class DeathActionProperties_Explosion : DeathActionProperties
    {
        public float radius;
        public DamageDef damType;
        public int damAmount;
        public float chanceToStartFire;
        public SoundDef sound = null;
        public ThingDef postExplosionSpawnThingDef = null;
        public float postExplosionSpawnChance = 0.5f;

        public DeathActionProperties_Explosion()
        {
            workerClass = typeof(DeathActionWorker_Explosion);
        }
    }
}
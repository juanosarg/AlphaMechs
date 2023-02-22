using RimWorld;
using Verse;
namespace AlphaMechs
{
    public class Projectile_Bombardment : Projectile
    {

        protected override void Impact(Thing hitThing, bool blockedByShield = false)
        {
            Map map = base.Map;
            base.Impact(hitThing, blockedByShield);

            Bombardment obj = (Bombardment)GenSpawn.Spawn(ThingDefOf.Bombardment, base.Position, map);
            obj.duration = 50;
            obj.instigator =this.launcher;
            obj.weaponDef =null;

        }
    }
}
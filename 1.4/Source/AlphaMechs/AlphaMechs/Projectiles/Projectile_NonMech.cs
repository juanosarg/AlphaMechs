using RimWorld;
using Verse;
namespace AlphaMechs
{
    public class Projectile_NonMech : Projectile
    {

        protected override void Impact(Thing hitThing, bool blockedByShield = false)
        {
            Map map = base.Map;

            Pawn pawn = hitThing as Pawn;
            if (pawn != null)
            {
                if (!pawn.RaceProps.IsMechanoid)
                {
                    base.Impact(hitThing, blockedByShield);
                }
            }
            

            

        }
    }
}
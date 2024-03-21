using AlphaMechs;
using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using Verse.AI.Group;

namespace AlphaMechs
{
    public class CompAddAbility : ThingComp
    {
       


        public CompProperties_AddAbility Props
        {
            get
            {
                return (CompProperties_AddAbility)this.props;
            }
        }

        public override void Notify_Equipped(Pawn pawn)
        {
            base.Notify_Equipped(pawn);
            pawn.abilities?.GainAbility(Props.ability);
        }

        public override void Notify_Unequipped(Pawn pawn)
        {
            base.Notify_Unequipped(pawn);
            pawn.abilities?.RemoveAbility(Props.ability);
        }

       






    }
}
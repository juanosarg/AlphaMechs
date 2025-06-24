using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using System.Reflection.Emit;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Verse.AI;

namespace AlphaMechs
{

    [HarmonyPatch(typeof(Building_MechCharger))]
    [HarmonyPatch("IsCompatibleWithCharger", new Type[] {typeof(ThingDef), typeof(ThingDef)})]

    public static class AlphaMechs_Building_MechCharger_IsCompatibleWithCharger_Patch
    {
        [HarmonyPostfix]
        public static void AddBossMechsToCharger(ThingDef chargerDef, ThingDef mechRace, ref bool __result)

        {

            MechSizeExtension extension = mechRace.GetModExtension<MechSizeExtension>();
            if (extension?.isBossSizeMech == true)
            {

                if (chargerDef == InternalDefOf.AM_GreaterRecharger)
                {
                  
                    __result = true;

                }
                else
                {
                 
                    __result = false;
                }
               
            }

            



        }
    }
}

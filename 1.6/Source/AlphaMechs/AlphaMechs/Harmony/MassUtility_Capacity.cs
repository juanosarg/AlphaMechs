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

    [HarmonyPatch(typeof(MassUtility))]
    [HarmonyPatch("Capacity")]

    public static class AlphaMechs_MassUtility_Capacity_Patch
    {
        [HarmonyPostfix]
        public static void IncreaseCarrying(Pawn p, ref float __result)

        {
            if (p.def == InternalDefOf.AM_PristineStrider) { 
                __result *= 8; 
            }



        }
    }
}

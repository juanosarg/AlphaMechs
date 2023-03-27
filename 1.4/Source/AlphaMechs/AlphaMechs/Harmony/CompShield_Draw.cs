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
using static HarmonyLib.Code;
using System.Security.Cryptography;


namespace AlphaMechs
{
    [StaticConstructorOnStartup]
    [HarmonyPatch(typeof(CompShield))]
    [HarmonyPatch("Draw")]
    public static class AlphaMechs_CompShield_Draw_Patch
    {

 
        private static readonly Material ForceFieldMat = MaterialPool.MatFrom("Things/Mote/AM_ShieldBubble", ShaderDatabase.MoteGlow);       
        private static List<ThingDef> mechsList = new List<ThingDef>() { InternalDefOf.AM_Mech_Legate,InternalDefOf.AM_WarEmpress,InternalDefOf.AM_Infernus,InternalDefOf.AM_Apoptosis};

        [HarmonyPrefix]
        public static bool ChangeShieldColour(CompShield __instance,float ___energy,int ___lastAbsorbDamageTick,Vector3 ___impactAngleVect)

        {

            if (ModsConfig.BiotechActive) {

                if (mechsList.Contains(ReflectionCache.PawnOwner(__instance).def) )
                {
                    if (__instance.ShieldState == ShieldState.Active && ReflectionCache.ShouldDisplay(__instance))
                    {
                        float num = Mathf.Lerp(__instance.Props.minDrawSize, __instance.Props.maxDrawSize, ___energy);
                        Vector3 drawPos = ReflectionCache.PawnOwner(__instance).Drawer.DrawPos;
                        drawPos.y = AltitudeLayer.MoteOverhead.AltitudeFor();
                        int num2 = Find.TickManager.TicksGame - ___lastAbsorbDamageTick;
                        if (num2 < 8)
                        {
                            float num3 = (float)(8 - num2) / 8f * 0.05f;
                            drawPos += ___impactAngleVect * num3;
                            num -= num3;
                        }
                        float angle = Rand.Range(0, 360);
                        Vector3 s = new Vector3(num, 1f, num);
                        Matrix4x4 matrix = default(Matrix4x4);
                        matrix.SetTRS(drawPos, Quaternion.AngleAxis(angle, Vector3.up), s);
                        Graphics.DrawMesh(MeshPool.plane10, matrix, ForceFieldMat, 0);
                    }
                    return false;
                }
            
            }

            return true;

            
           


        }

       



    }
}

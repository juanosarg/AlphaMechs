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
    [HarmonyPatch(typeof(CompProjectileInterceptor))]
    [HarmonyPatch("PostDraw")]
    public static class AlphaMechs_CompProjectileInterceptor_PostDraw_Patch
    {

        private static readonly Color InactiveColor = new Color(0.2f, 0.2f, 0.2f);
        private static readonly MaterialPropertyBlock MatPropertyBlock = new MaterialPropertyBlock();
        private static readonly Material ForceFieldMat = MaterialPool.MatFrom("Things/Mote/AM_ShieldBubble", ShaderDatabase.MoteGlow);
        private static readonly Material ForceFieldConeMat = MaterialPool.MatFrom("Other/ForceFieldCone", ShaderDatabase.MoteGlow);
        private static List<ThingDef> mechsList = new List<ThingDef>() { InternalDefOf.AM_Mech_Legate,InternalDefOf.AM_WarEmpress,InternalDefOf.AM_Infernus,InternalDefOf.AM_Apoptosis};

        [HarmonyPrefix]
        public static bool ChangeShieldColour(CompProjectileInterceptor __instance, float ___lastInterceptAngle)

        {

            if (ModsConfig.BiotechActive) {

                if (mechsList.Contains(__instance.parent.def) )
                {
                    Vector3 drawPos = __instance.parent.DrawPos;
                    drawPos.y = AltitudeLayer.MoteOverhead.AltitudeFor();
                    float currentAlpha = ReflectionCache.getCurrentAlpha(__instance);
                    if (currentAlpha > 0f)
                    {
                        Color value = ((!__instance.Active && Find.Selector.IsSelected(__instance.parent)) ? InactiveColor : __instance.Props.color);
                        value.a *= currentAlpha;
                        MatPropertyBlock.SetColor(ShaderPropertyIDs.Color, value);
                        Matrix4x4 matrix = default(Matrix4x4);
                        matrix.SetTRS(drawPos, Quaternion.identity, new Vector3(__instance.Props.radius * 2f * 1.16015625f, 1f, __instance.Props.radius * 2f * 1.16015625f));
                        Graphics.DrawMesh(MeshPool.plane10, matrix, ForceFieldMat, 0, null, 0, MatPropertyBlock);
                    }
                    float currentConeAlpha_RecentlyIntercepted = ReflectionCache.getCurrentConeAlpha_RecentlyIntercepted(__instance);
                    if (currentConeAlpha_RecentlyIntercepted > 0f)
                    {
                        Color color = __instance.Props.color;
                        color.a *= currentConeAlpha_RecentlyIntercepted;
                        MatPropertyBlock.SetColor(ShaderPropertyIDs.Color, color);
                        Matrix4x4 matrix2 = default(Matrix4x4);
                        matrix2.SetTRS(drawPos, Quaternion.Euler(0f, ___lastInterceptAngle - 90f, 0f), new Vector3(__instance.Props.radius * 2f * 1.16015625f, 1f, __instance.Props.radius * 2f * 1.16015625f));
                        Graphics.DrawMesh(MeshPool.plane10, matrix2, ForceFieldConeMat, 0, null, 0, MatPropertyBlock);
                    }
                    return false;
                }
            
            }

            return true;

            
           


        }

      

    }
}

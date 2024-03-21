using HarmonyLib;
using RimWorld;
using Verse;
using System;
using System.Collections.Generic;



namespace AlphaMechs
{
    public class ReflectionCache
    {
        public static readonly Func<CompProjectileInterceptor,float> getCurrentAlpha = (Func<CompProjectileInterceptor,float>)Delegate.CreateDelegate(typeof(Func<CompProjectileInterceptor,float>),
            AccessTools.Method(typeof(CompProjectileInterceptor), "GetCurrentAlpha"));

        public static readonly Func<CompProjectileInterceptor,float> getCurrentConeAlpha_RecentlyIntercepted = (Func<CompProjectileInterceptor,float>)Delegate.CreateDelegate(typeof(Func<CompProjectileInterceptor,float>),
            AccessTools.Method(typeof(CompProjectileInterceptor), "GetCurrentConeAlpha_RecentlyIntercepted"));

        public static readonly Func<CompShield, bool> ShouldDisplay = (Func<CompShield, bool>)Delegate.CreateDelegate(typeof(Func<CompShield, bool>),
           AccessTools.PropertyGetter(typeof(CompShield), "ShouldDisplay"));

        public static readonly Func<CompShield, Pawn> PawnOwner = (Func<CompShield, Pawn>)Delegate.CreateDelegate(typeof(Func<CompShield, Pawn>),
           AccessTools.PropertyGetter(typeof(CompShield), "PawnOwner"));


    }
}

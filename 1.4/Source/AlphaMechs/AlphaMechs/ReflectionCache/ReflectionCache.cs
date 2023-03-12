using HarmonyLib;
using RimWorld;
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

        
    }
}

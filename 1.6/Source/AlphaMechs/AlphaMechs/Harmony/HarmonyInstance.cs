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
using RimWorld.Planet;



namespace AlphaMechs
{

    public class AlphaMechs : Mod
    {
        public AlphaMechs(ModContentPack content) : base(content)
        {
            var harmony = new Harmony("com.alphamechs");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

}

















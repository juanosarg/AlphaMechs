
using Verse;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Diagnostics;

using Verse.Sound;
using UnityEngine;
using System.Collections;
using static HarmonyLib.Code;
using System.Linq;

namespace AlphaMechs
{
    public class Projectile_Distortion : Projectile_Explosive
    {



        public override void Tick()
        {
            base.Tick();
            if (this.IsHashIntervalTick(10))
            {
                try
                {
                    FleckMaker.AttachedOverlay(this, FleckDefOf.PsycastAreaEffect, Vector3.zero, 3f, -1f);
                }
                catch (Exception) { }

            }
            if (this.IsHashIntervalTick(50))
            {
                var target = NextTarget();
                if (target != null)
                {
                    FireAt(target);
                }
            }
            
        }


        private Thing NextTarget()
        {
            var things = GenRadial.RadialDistinctThingsAround(this.PositionHeld, Map, 15, false)
                .Where(t => (t.HostileTo(this.launcher)));
            
            things = things.OrderBy(t => t.Position.DistanceTo(this.Position));
            var target = things.FirstOrDefault();
            return target;
        }

        public void FireAt(Thing target)
        {
            var projectile = (Projectile)GenSpawn.Spawn(InternalDefOf.AM_Bullet_Starfire_Secondary, Position, Map);
            projectile.Launch(launcher, target, target, this.HitFlags, false);
          
        }





    }
}
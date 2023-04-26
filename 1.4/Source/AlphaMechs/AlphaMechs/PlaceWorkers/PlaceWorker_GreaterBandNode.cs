
using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;
namespace AlphaMechs
{
    public class PlaceWorker_GreaterBandNode : PlaceWorker
    {

        List<ThingDef> listBandNodes = new List<ThingDef>() { ThingDefOf.BandNode,InternalDefOf.AM_BeamcasterBandNode, InternalDefOf.AM_GreaterBandNode};

        public override AcceptanceReport AllowsPlacing(BuildableDef def, IntVec3 center, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            foreach (IntVec3 item in GenAdj.OccupiedRect(center, rot, def.Size).ExpandedBy(1))
            {
                if (!item.InBounds(map))
                {
                    continue;
                }
                List<Thing> thingList = item.GetThingList(map);
                for (int i = 0; i < thingList.Count; i++)
                {
                    if (listBandNodes.Contains(thingList[i].def) || listBandNodes.Contains(thingList[i].def.entityDefToBuild))
                    {
                        return "AM_MustNotBePlacedCloseToAnother".Translate();
                    }
                }
            }
            return true;
        }
    }
}

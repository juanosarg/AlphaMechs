using Verse;
using System.Collections.Generic;
using System.Linq;

namespace AlphaMechs
{
    [StaticConstructorOnStartup]
    public static class StaticCollections
    {

        public static List<PawnKindDef> blacklistedMechs = new List<PawnKindDef>();
      
        static StaticCollections()
        {

            HashSet<WarcasketAbilityMechBlacklistDef> allMechBlacklists = DefDatabase<WarcasketAbilityMechBlacklistDef>.AllDefsListForReading.ToHashSet();
            foreach (WarcasketAbilityMechBlacklistDef individualList in allMechBlacklists)
            {
                foreach (string mech in individualList.blacklistedMechs)
                {
                    PawnKindDef mechDef = DefDatabase<PawnKindDef>.GetNamedSilentFail(mech);
                    if (mechDef != null)
                    {
                        blacklistedMechs.Add(mechDef);
                    }
                }              
            }        
        }       
    }
}

using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace BrawlersDontMindGrenades
{
    [HarmonyPatch(typeof(Alert_BrawlerHasRangedWeapon), nameof(Alert_BrawlerHasRangedWeapon.BrawlersWithRangedWeapon), MethodType.Getter)]
    public class Alert_BrawlerHasRangedWeapon_BrawlersWithRangedWeapon
    {
        public static List<Pawn> Postfix(List<Pawn> __result,  Alert_BrawlerHasRangedWeapon __instance)
        {
            __instance.brawlersWithRangedWeaponResult.Clear();
            foreach (Pawn p in PawnsFinder.AllMaps_FreeColonistsSpawned)
            {
                if (p.story.traits.HasTrait(TraitDefOf.Brawler) && p.equipment.Primary != null && p.equipment.Primary.def.IsRangedWeapon)
                {
                    if (!p.equipment.Primary.def.defName.Contains("Weapon_Grenade"))
                    {
                        __instance.brawlersWithRangedWeaponResult.Add(p);
                    }
                }
            }
            return __instance.brawlersWithRangedWeaponResult;
        }
    }

    [HarmonyPatch(typeof(ThoughtWorker_IsCarryingRangedWeapon), nameof(ThoughtWorker_IsCarryingRangedWeapon.CurrentStateInternal))]
    public class ThoughtWorker_IsCarryingRangedWeapon_CurrentStateInternal
    {
        public static ThoughtState Postfix(ThoughtState __result, Pawn p)
        {
            if (__result.Active)
            {
                if (p.equipment.Primary.def.defName.StartsWith("Weapon_Grenade"))
                {
                    return false;
                }
            }

            return __result;
        }
    }
}

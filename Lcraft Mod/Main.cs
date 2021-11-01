using System;
using System.Collections.Generic;
using Assets.Main.Scenes;
using Assets.Scripts.Models.Powers;
using Assets.Scripts.Models.Profile;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Input;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Towers.Weapons;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Upgrade;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Api.Towers;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Main.Scenes;
using Assets.Scripts.Models;
using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Powers;
using Assets.Scripts.Models.Profile;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity.UI_New.InGame.StoreMenu;
using Assets.Scripts.Unity.UI_New.Upgrade;
using Assets.Scripts.Utils;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using Assets.Scripts.Models.Towers.Weapons;
using System.Net;
using Assets.Scripts.Unity.UI_New.Popups;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper;

namespace Lcraft_Mod
{
    public class Main : MelonMod
    {
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            MelonLogger.Log("Lcraft Mod ´has been loaded");
        }

        static float multi = 5;



        [HarmonyPatch(typeof(Simulation), "AddCash")]
        public class MoreCash
        {
            [HarmonyPrefix]
            public static bool Prefix(ref double c, ref Simulation.CashSource source)
            {
                if (source != Simulation.CashSource.CoopTransferedCash && source != Simulation.CashSource.TowerSold) c *= multi;
                return true;

            }
        }
    }

    [HarmonyPatch(typeof(Tower), "Initialise")]
    public class Tower_Range
    {
        [HarmonyPostfix]
        public static void Postfix(Tower __instance)
        {
            __instance.towerModel.range = 999999f;
            __instance.towerModel.isGlobalRange = true;
        }
    }

    [HarmonyPatch(typeof(Tower), "UpdatedModel")]
    public class Tower_RangeUpdatedModel
    {
        [HarmonyPostfix]
        public static void Postfix(Tower __instance)
        {
            __instance.towerModel.range = 999999f;
            __instance.towerModel.isGlobalRange = true;
        }
    }

    [HarmonyPatch(typeof(Weapon), "Initialise")]
    internal class Weapon_SpeedInitialise
    {
        [HarmonyPostfix]
        internal static void Postfix(Weapon __instance)
        {
            __instance.weaponModel.rate = 1;
        }
    }

    [HarmonyPatch(typeof(Weapon), "UpdatedModel")]
    internal class Weapon_SpeedUpdatedModel_Patch
    {
        [HarmonyPostfix]
        internal static void Postfix(Weapon __instance)
        {
            __instance.weaponModel.rate = 1;
        }
    }


    /*public class BannaFarmer: BloonsTD6Mod
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250

		// Token: 0x04000001 RID: 1
		public static ModSettingInt price = new ModSettingInt(550);

		// Token: 0x02000003 RID: 3
		[HarmonyPatch(typeof(ProfileModel), "Validate")]
		public class ProfileModel_Patch
		{
			// Token: 0x06000004 RID: 4 RVA: 0x00002078 File Offset: 0x00000278
			[HarmonyPostfix]
			public static void Postfix(ProfileModel __instance)
			{
                System.Collections.Generic.HashSet<string> unlockedTowers = __instance.unlockedTowers;
				if (unlockedTowers.Contains("BananaFarmer"))
				{
					MelonLogger.Msg("Banana Farmer already unlocked");
					return;
				}
				MelonLogger.Msg("unlocking Banana Farmer");
				unlockedTowers.Add("BananaFarmer");
			}
		}

		// Token: 0x02000004 RID: 4
		[HarmonyPatch(typeof(TitleScreen), "UpdateVersion")]
		public class TitleScreen_Patch
		{
			// Token: 0x06000006 RID: 6 RVA: 0x000020C4 File Offset: 0x000002C4
			[HarmonyPostfix]
			public static void Postfix()
			{
				PowerModel powerWithName = Game.instance.model.GetPowerWithName("BananaFarmer");
				if (powerWithName.tower.icon == null)
				{
					powerWithName.tower.icon = powerWithName.icon;
				}
				powerWithName.tower.cost = (float)BannaFarmer.price;
				powerWithName.tower.towerSet = "Support";
			}
		}

		// Token: 0x02000005 RID: 5
		[HarmonyPatch(typeof(TowerInventory), "Init")]
		public class TowerInventory_Patch
		{
			// Token: 0x06000008 RID: 8 RVA: 0x00002138 File Offset: 0x00000338
			[HarmonyPrefix]
			public static void Prefix(ref List<TowerDetailsModel> allTowersInTheGame)
			{
				ShopTowerDetailsModel shopTowerDetailsModel = new ShopTowerDetailsModel("BananaFarmer", 1, 0, 0, 0, -1, 0, null);
				allTowersInTheGame.Add(shopTowerDetailsModel);
			}
		}

		// Token: 0x02000006 RID: 6
		[HarmonyPatch(typeof(UpgradeScreen), "UpdateUi")]
		public class UpgradeScreen_Patch
		{
			// Token: 0x0600000A RID: 10 RVA: 0x00002167 File Offset: 0x00000367
			[HarmonyPrefix]
			public static void Prefix(ref string towerId)
			{
				if (towerId.Contains("BananaFarmer"))
				{
					towerId = "DartMonkey";
				}
			}
		}
	}*/

}

using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Unity;
using UnhollowerBaseLib;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Display;
using Assets.Scripts.Unity.Display;
using MelonLoader;

namespace MoreTowersMod
{
    public class BloonChipperTower : ModTower
    {
        public override string BaseTower => "PatFusty 20";
        public override string Name => "Bloonchipper";
        public override int Cost => 420;
        public override string TowerSet => "Military";
        public override int TopPathUpgrades => 2;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 1;
        public override string DisplayName => "Bloonchipper";
        public override string Description => "Rapidly sucks up and shreds bloons, spitting what's left out the back.";
        public override string Get2DTexture(int[] tiers)
        {
            if (tiers[1] >= 4)
            {
                return "FireSucc_Icon_Bloonshipper";
            }
            return "Icon_Bloonshipper";
        }
        public override bool Use2DModel => true;

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            MelonLogger.Log("Bloonshipper: Remove Hero");
            // Removes Hero
            towerModel.GetAttackModel().weapons[0].projectile.RemoveBehavior<CreateSoundOnDelayedCollisionModel>();
            towerModel.RemoveBehavior<CreateSoundOnBloonEnterTrackModel>();
            towerModel.RemoveBehavior<CreateSoundOnBloonLeakModel>();
            towerModel.RemoveBehavior<CreateSoundOnSelectedModel>();
            towerModel.RemoveBehavior<AbilityModel>();
            towerModel.RemoveBehavior<AbilityModel>();
            towerModel.RemoveBehavior<HeroModel>();

            MelonLogger.Log("Bloonshipper: Add Blop Sound");
            // Add Baloons Blop Sound
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("DartMonkey").GetBehavior<CreateSoundOnUpgradeModel>().Duplicate());
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("DartMonkey").GetBehavior<CreateEffectOnUpgradeModel>().Duplicate());

            MelonLogger.Log("Bloonshipper: Manage Combat");
            // Combat
            AttackModel attackModel = towerModel.GetAttackModel();
            attackModel.weapons[0].Rate = 3;
            attackModel.weapons[0].projectile.pierce = 1;
            attackModel.weapons[0].projectile.maxPierce = 3;
            attackModel.weapons[0].projectile.SetHitCamo(false);

            /*MelonLogger.Log("Bloonshipper: Edit Baloons Animations");
            // Edit Baloons Animation
            attackModel.weapons[0].GetBehavior<SwitchAnimStateForBloonTypeModel>().nonMoabsAnimId = 4;
            attackModel.weapons[0].GetBehavior<SwitchAnimStateForBloonTypeModel>().moabAnimId = 4;
            attackModel.weapons[0].GetBehavior<SwitchAnimStateForBloonTypeModel>().bfbAnimId = 4;
            attackModel.weapons[0].GetBehavior<SwitchAnimStateForBloonTypeModel>().zomgAnimId = 4;
            attackModel.weapons[0].GetBehavior<SwitchAnimStateForBloonTypeModel>().ddtAnimId = 4;*/

            MelonLogger.Log("Bloonshipper: Make Target System");
            // Target System
            attackModel.GetBehavior<TargetStrongModel>().isSelectable = true;
            attackModel.AddBehavior<TargetFirstModel>(new TargetFirstModel("TargetFirstModel", true, false));

            MelonLogger.Log("Bloonshipper: Register Model");
            // Register Model
            towerModel.AddBehavior(attackModel);
            towerModel.ApplyDisplay<BloonShipperTowerDisplay>();
        }
        public override string Icon => "Icon_Bloonshipper";
        public override string Portrait => "Portrait_Bloonshipper";
        public override float PixelsPerUnit => 8f;
    }

    public class BloonShipperTowerDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, Name);
        }
    }
}

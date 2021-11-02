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
            // Removes Hero Model
            towerModel.RemoveBehavior<HeroModel>();
            towerModel.RemoveBehavior<AttackModel>();
            towerModel.RemoveBehavior<AbilityModel>();
            towerModel.RemoveBehavior<AbilityModel>();

            // Removes Hero Sounds
            towerModel.RemoveBehavior<CreateSoundOnBloonEnterTrackModel>();
            towerModel.RemoveBehavior<CreateSoundOnBloonLeakModel>();
            towerModel.RemoveBehavior<CreateSoundOnSelectedModel>();
            towerModel.RemoveBehavior<CreateEffectOnUpgradeModel>();
            towerModel.GetAttackModel().weapons[0].projectile.RemoveBehavior<CreateSoundOnDelayedCollisionModel>();

            // Add Baloons Blop Sound
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("DartMonkey").GetBehavior<CreateSoundOnUpgradeModel>().Duplicate());
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("DartMonkey").GetBehavior<CreateEffectOnUpgradeModel>().Duplicate());

            var squeeze = towerModel.GetAbility(1).GetBehavior<ActivateAttackModel>().attacks[0].Duplicate();

            // Remove Baloons Animation
            squeeze.weapons[0].GetBehavior<SwitchAnimStateForBloonTypeModel>().nonMoabsAnimId = 4;
            squeeze.weapons[0].GetBehavior<SwitchAnimStateForBloonTypeModel>().moabAnimId = 4;
            squeeze.weapons[0].GetBehavior<SwitchAnimStateForBloonTypeModel>().bfbAnimId = 4;
            squeeze.weapons[0].GetBehavior<SwitchAnimStateForBloonTypeModel>().zomgAnimId = 4;
            squeeze.weapons[0].GetBehavior<SwitchAnimStateForBloonTypeModel>().ddtAnimId = 4;

            // Target System
            squeeze.GetBehavior<TargetStrongModel>().isSelectable = true;
            squeeze.AddBehavior<TargetFirstModel>(new TargetFirstModel("TargetFirstModel", true, false));

            // Combat
            squeeze.weapons[0].Rate = 3;
            squeeze.weapons[0].projectile.pierce = 1;
            squeeze.weapons[0].projectile.maxPierce = 3;

            // Register Model
            towerModel.AddBehavior<AttackModel>(squeeze);
        }
        public override string Icon => "Icon_Bloonshipper";
        public override string Portrait => "Portrait_Bloonshipper";
        public override float PixelsPerUnit => 8f;
    }
}

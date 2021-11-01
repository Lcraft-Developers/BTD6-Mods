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
    public class BloonChipperTower : BloonsTD6Mod
    {
        public class BloonChipper : ModTower
        {
            public override string BaseTower => "PatFusty 20";
            public override string Name => "Bloonchipper";
            public override int Cost => 420;
            public override string TowerSet => "Military";
            public override int TopPathUpgrades => 4;
            public override int MiddlePathUpgrades => 4;
            public override int BottomPathUpgrades => 0;
            public override string DisplayName => "Bloonchipper";
            public override string Description => "Rapidly sucks up and shreds bloons, spitting what's left out the back.";
            public override string Get2DTexture(int[] tiers)
            {
                return "Portrait";
            }
            public override bool Use2DModel => true;
            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {
                towerModel.RemoveBehavior<HeroModel>();
                towerModel.RemoveBehavior<CreateSoundOnBloonEnterTrackModel>();
                towerModel.RemoveBehavior<CreateSoundOnBloonLeakModel>();
                towerModel.RemoveBehavior<CreateSoundOnSelectedModel>();
                towerModel.AddBehavior(Game.instance.model.GetTowerFromId("DartMonkey").GetBehavior<CreateSoundOnUpgradeModel>().Duplicate());
                towerModel.RemoveBehavior<CreateEffectOnUpgradeModel>();
                towerModel.AddBehavior(Game.instance.model.GetTowerFromId("DartMonkey").GetBehavior<CreateEffectOnUpgradeModel>().Duplicate());
                var squeeze = towerModel.GetAbility(1).GetBehavior<ActivateAttackModel>().attacks[0].Duplicate<AttackModel>();
                squeeze.weapons[0].Rate = 3;
                squeeze.weapons[0].GetBehavior<SwitchAnimStateForBloonTypeModel>().nonMoabsAnimId = 4;
                squeeze.weapons[0].GetBehavior<SwitchAnimStateForBloonTypeModel>().moabAnimId = 4;
                squeeze.weapons[0].GetBehavior<SwitchAnimStateForBloonTypeModel>().bfbAnimId = 4;
                squeeze.weapons[0].GetBehavior<SwitchAnimStateForBloonTypeModel>().zomgAnimId = 4;
                squeeze.weapons[0].GetBehavior<SwitchAnimStateForBloonTypeModel>().ddtAnimId = 4;
                squeeze.GetBehavior<TargetStrongModel>().isSelectable = true;
                squeeze.AddBehavior<TargetFirstModel>(new TargetFirstModel("TargetFirstModel_", true, false));
                squeeze.weapons[0].projectile.pierce = 1;
                squeeze.weapons[0].projectile.maxPierce = 3;
                squeeze.weapons[0].projectile.CapPierce(5);
                towerModel.RemoveBehavior<AttackModel>();
                towerModel.AddBehavior<AttackModel>(squeeze);
                towerModel.RemoveBehavior<AbilityModel>();
                towerModel.RemoveBehavior<AbilityModel>();
                towerModel.GetAttackModel().weapons[0].projectile.RemoveBehavior<CreateSoundOnDelayedCollisionModel>();
            }
            public override string Icon => "Icon";
            public override string Portrait => "Portrait";
            public override float PixelsPerUnit => 8f;
        }
    }
}

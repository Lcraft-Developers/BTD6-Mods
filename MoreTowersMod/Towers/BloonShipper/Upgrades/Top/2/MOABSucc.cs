using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Towers;
using static MoreTowersMod.BloonChipperTower;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Unity;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors;

namespace MoreTowersMod.Upgrades.BloonShipper.Top._2
{
    public class MOABSucc : ModUpgrade<BloonChipper>
    {
        public override string Name => "MOABSucc";
        public override string DisplayName => "MOAB Killer";
        public override string Description => "Can now destroy moabs. Ability doubles attack speed.";
        public override int Cost => 9200;
        public override int Path => TOP;
        public override int Tier => 2;
        public override string Icon => "Icon";
        public override string Portrait => "Portrait";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].projectile.GetBehavior<DelayBloonChildrenSpawningModel>().Lifespan *= 0.5f;
            attackModel.AddWeapon(attackModel.weapons[0].Duplicate<WeaponModel>());
            attackModel.weapons[1].projectile.pierce = 7;
            attackModel.weapons[1].projectile.maxPierce = 13;
            attackModel.weapons[1].projectile.CapPierce(999);
            attackModel.range += 20;
            towerModel.range += 20;
            attackModel.weapons[0].projectile.radius += 30;

            AbilityModel abilityModel = Game.instance.model.GetTowerFromId("PatFusty 20").GetAbility().Duplicate();
            abilityModel.icon = GetSpriteReference(mod, "Bloonchipper");
            ActivateTowerDamageSupportZoneModel a = abilityModel.GetBehavior<ActivateTowerDamageSupportZoneModel>();
            ActivateRateSupportZoneModel arszm = new ActivateRateSupportZoneModel(a.name, a.mutatorId, a.isUnique, 0.5f, 0.1f, 1, a.canEffectThisTower, a.lifespan, null, a.buffLocsName, a.buffIconName, a.filters, false);
            abilityModel.AddBehavior<ActivateRateSupportZoneModel>(arszm);
            abilityModel.RemoveBehavior<ActivateTowerDamageSupportZoneModel>();
            towerModel.AddBehavior(abilityModel);

            // TODO: Camo and MOAB Detection
            attackModel.weapons[0].projectile.GetBehavior<DelayBloonChildrenSpawningModel>().Lifespan *= 3f;
        }
    }
}

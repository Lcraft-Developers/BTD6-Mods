using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Towers;
using static MoreTowersMod.BloonChipperTower;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace MoreTowersMod.Upgrades.BloonShipper.Middle._4
{
    public class QuadSucc : ModUpgrade<BloonChipper>
    {
        public override string Name => "QuadSucc";
        public override string DisplayName => "Quad Killer";
        public override string Description => "Can now destroy 4 blimps at once, and attacks bloons much faster. Even Attacks Every Baloon At One Time!";
        public override int Cost => 136000;
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override string Icon => "Icon";
        public override string Portrait => "Portrait";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].projectile.maxPierce = 17;
            attackModel.weapons[0].projectile.pierce = 13;
            attackModel.weapons[0].Rate *= 0.04f;
            attackModel.weapons[0].projectile.GetBehavior<DelayBloonChildrenSpawningModel>().Lifespan *= 1f;
        }
    }
}

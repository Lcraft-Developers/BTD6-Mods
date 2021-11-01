using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Towers;
using static MoreTowersMod.BloonChipperTower;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace MoreTowersMod.Upgrades.BloonShipper.Middle._2
{
    public class SimpleShredder : ModUpgrade<BloonChipper>
    {
        public override string Name => "SimpleShredder";
        public override string DisplayName => "Its shreds like a Shredder";
        public override string Description => "Attacks three times faster.";
        public override int Cost => 950;
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override string Icon => "Icon";
        public override string Portrait => "Portrait";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].projectile.pierce = 3f;
            attackModel.weapons[0].Rate = 0.5f;
            attackModel.weapons[0].projectile.GetBehavior<DelayBloonChildrenSpawningModel>().Lifespan *= 2f;
        }
    }
}

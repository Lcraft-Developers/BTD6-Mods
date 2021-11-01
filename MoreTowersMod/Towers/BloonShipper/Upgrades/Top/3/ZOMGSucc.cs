using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Towers;
using static MoreTowersMod.BloonChipperTower;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace MoreTowersMod.Upgrades.BloonShipper.Top._3
{
    public class ZOMGSucc : ModUpgrade<BloonChipper>
    {
        public override string Name => "Attack All Bloons";
        public override string DisplayName => "ZOMG Killer";
        public override string Description => "Can now destroy Every Baloon! and instakill bloons.";
        public override int Cost => 32000;
        public override int Path => TOP;
        public override int Tier => 3;
        public override string Icon => "Bloonchipper";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].projectile.GetBehavior<DamageModel>().distributeToChildren = true;
            attackModel.weapons[0].projectile.GetBehavior<DamageModel>().overrideDistributeBlocker = true;
        }
    }
}

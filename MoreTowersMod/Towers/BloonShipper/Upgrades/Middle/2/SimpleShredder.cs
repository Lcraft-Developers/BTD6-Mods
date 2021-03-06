using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Towers;
using static MoreTowersMod.BloonChipperTower;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace MoreTowersMod.Upgrades.BloonShipper.Middle._2
{
    public class SimpleShredder : ModUpgrade<BloonChipperTower>
    {
        public override string Name => "SimpleShredder";
        public override string DisplayName => "Its shreds like a Shredder";
        public override string Description => "Attacks three times faster.";
        public override int Cost => 1250;
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override string Icon => "SimpleShredder_Icon_Bloonshipper";
        public override string Portrait => "SimpleShredder_Portrait_Bloonshipper";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].Rate = 0.5f;
            attackModel.weapons[0].projectile.pierce = 3;
            attackModel.weapons[0].projectile.maxPierce = 7;
        }
    }
}

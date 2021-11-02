using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Towers;
using static MoreTowersMod.BloonChipperTower;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using UnhollowerBaseLib;
using Assets.Scripts.Models.Towers.Filters;

namespace MoreTowersMod.Upgrades.BloonShipper.Middle._3
{
    public class GoodShredder : ModUpgrade<BloonChipperTower>
    {
        public override string Name => "GoodShredder";
        public override string DisplayName => "Shreeder is fastes as a car";
        public override string Description => "Attacks all types of baloons.";
        public override int Cost => 2300;
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override string Icon => "GoodShredder_Icon_Bloonshipper";
        public override string Portrait => "GoodShredder_Portrait_Bloonshipper";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].Rate = 0.2f;
            attackModel.weapons[0].projectile.pierce = 5;
            attackModel.weapons[0].projectile.maxPierce = 7;
        }
    }
}

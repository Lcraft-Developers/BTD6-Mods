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
    public class GoodShredder : ModUpgrade<BloonChipper>
    {
        public override string Name => "GoodShredder";
        public override string DisplayName => "Shreeder sees everything";
        public override string Description => "Attacks all types of baloons.";
        public override int Cost => 1300;
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override string Icon => "Bloonchipper";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].projectile.pierce = 4;
            attackModel.weapons[0].Rate = 0.75f;
            attackModel.weapons[0].projectile.GetBehavior<DelayBloonChildrenSpawningModel>().Lifespan *= 4f;
            // TODO: All Baloons and MOAB Detection
        }
    }
}

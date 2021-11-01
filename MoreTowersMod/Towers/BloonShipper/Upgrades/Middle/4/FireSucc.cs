using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Towers;
using static MoreTowersMod.BloonChipperTower;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace MoreTowersMod.Upgrades.BloonShipper.Top._4
{
    public class FireSucc : ModUpgrade<BloonChipper>
    {
        public override string Name => "FireKiller";
        public override string DisplayName => "Fire Killer";
        public override string Description => "Can now destroy all types of Baloons and fire them inside of the machine.";
        public override int Cost => 17000;
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override string Icon => "FireIcon";
        public override string Portrait => "FirePortrait";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].Rate *= 0.3f;
            attackModel.weapons[0].projectile.pierce = 9;
            attackModel.weapons[0].projectile.maxPierce = 13;
            attackModel.weapons[0].projectile.GetBehavior<DelayBloonChildrenSpawningModel>().Lifespan *= 1f;
        }
    }
}

using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Towers;
using static MoreTowersMod.BloonChipperTower;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace MoreTowersMod.Upgrades.BloonShipper.Top._4
{
    public class FireSucc : ModUpgrade<BloonChipperTower>
    {
        public override string Name => "FireKiller";
        public override string DisplayName => "Fire Killer";
        public override string Description => "Can now destroy all types of Baloons and fire them inside of the machine.";
        public override int Cost => 19200;
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override string Icon => "FireSucc_Icon_Bloonshipper";
        public override string Portrait => "FireSucc_Portrait_Bloonshipper";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].Rate = 0.1f;
            attackModel.weapons[0].projectile.pierce = 9;
            attackModel.weapons[0].projectile.maxPierce = 11;
        }
    }
}

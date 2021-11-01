using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Towers;
using static MoreTowersMod.BloonChipperTower;

namespace MoreTowersMod.Upgrades.BloonShipper.Middle._1
{
    public class FasterSucc : ModUpgrade<BloonChipper>
    {
        public override string Name => "FasterSucc";
        public override string DisplayName => "Faster Shred";
        public override string Description => "Attacks twice as fast.";
        public override int Cost => 230;
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override string Icon => "Icon";
        public override string Portrait => "Portrait";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].projectile.pierce = 2f;
            attackModel.weapons[0].Rate = 1.5f;
        }
    }
}

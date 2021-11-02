using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Towers;
using static MoreTowersMod.BloonChipperTower;

namespace MoreTowersMod.Upgrades.BloonShipper.Top._1
{
    public class LongerSucc : ModUpgrade<BloonChipperTower>
    {
        public override string Name => "LongerSucc";
        public override string DisplayName => "Longer Range";
        public override string Description => "Increased range and pierce.";
        public override int Cost => 130;
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override string Icon => "LongerSucc_Portrait_Bloonshipper";
        public override string Portrait => "LongerSucc_Portrait_Bloonshipper";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range += 20;
            towerModel.range += 20;
            attackModel.weapons[0].projectile.radius += 20;
        }
    }
}

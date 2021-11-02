using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Towers;
using static MoreTowersMod.BloonChipperTower;

namespace MoreTowersMod.Upgrades.BloonShipper.Top._1
{
    public class BaloonsDetect : ModUpgrade<BloonChipperTower>
    {
        public override string Name => "BaloonsDetect";
        public override string DisplayName => "Baloons Detector";
        public override string Description => "Can detects and destory all types of baloons.";
        public override int Cost => 830;
        public override int Path => TOP;
        public override int Tier => 1;
        public override string Icon => "BaloonsDetect_Icon_Bloonshipper";
        public override string Portrait => "BaloonsDetect_Portrait_Bloonshipper";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range += 5;
            towerModel.range += 5;
            attackModel.weapons[0].projectile.radius += 3;
            attackModel.weapons[0].projectile.SetHitCamo(true);
        }
    }
}

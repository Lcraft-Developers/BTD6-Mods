﻿using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Towers;
using static MoreTowersMod.BloonChipperTower;

namespace MoreTowersMod.Upgrades.BloonShipper.Top._1
{
    public class LongerSucc : ModUpgrade<BloonChipper>
    {
        public override string Name => "LongerSucc";
        public override string DisplayName => "Longer Range";
        public override string Description => "Increased range and pierce.";
        public override int Cost => 130;
        public override int Path => TOP;
        public override int Tier => 1;
        public override string Icon => "Bloonchipper";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].projectile.pierce = 1;
            attackModel.range += 15;
            towerModel.range += 15;
            attackModel.weapons[0].projectile.radius += 15;
        }
    }
}
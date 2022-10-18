using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Items
{
	public class CheeseAndCrackers : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Summons a Shade pet");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ModContent.ProjectileType<Projectiles.Pets.ShadePet>();
			item.buffType = ModContent.BuffType<Buffs.ShadePetBuff>();
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}








//https://youtu.be/KfOKejmQc1o?t=3802
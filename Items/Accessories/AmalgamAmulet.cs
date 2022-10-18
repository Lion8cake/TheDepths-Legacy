using TheDepths.Tiles;
using TheDepths.Buffs;
using TheDepths.Items.Placeable;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheDepths.Items.Accessories
{
	public class AmalgamAmulet : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Grants immunity to Mercury Boiling");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.value = 300000;
			item.rare = ItemRarityID.Orange;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
            player.buffImmune[ModContent.BuffType<MercuryBoiling>()] = true;
		}
	}
}
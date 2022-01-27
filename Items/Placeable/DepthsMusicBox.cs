using Terraria.ModLoader;
using Terraria.ID;

namespace TheDepths.Items.Placeable
{
	public class DepthsMusicBox : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Music Box (Depths)");
		}

		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.DepthsMusicBox>();
			item.width = 24;
			item.height = 24;
			item.rare = ItemRarityID.LightRed;
			item.value = 100000;
			item.accessory = true;
		}
	}
}

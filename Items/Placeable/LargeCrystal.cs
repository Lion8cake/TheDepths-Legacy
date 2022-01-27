using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Items.Placeable
{
	public class LargeCrystal : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 99;
			item.value = 1000;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.LargeCrystal>();
			item.rare = ItemRarityID.White;
		}
	}
}

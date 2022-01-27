using TheDepths.Items.Placeable;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Items.Placeable
{
	public class ArqueriteBricks : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 999;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.ArqueriteBricks>();
			item.width = 12;
			item.height = 12;
			item.rare = ItemRarityID.Green;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 1);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.ArqueriteOre>(), 1);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

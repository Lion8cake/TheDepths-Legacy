using Terraria.ModLoader;
using Terraria.ID;

namespace TheDepths.Items.Placeable
{
	public class ArqueriteBrickWall : ModItem
	{
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 7;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createWall = ModContent.WallType<Walls.ArqueriteBrickWall>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ArqueriteBricks>());
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
		}
	}
}
using TheDepths.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheDepths.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class MercuryGreaves : ModItem
	{
		public override void SetStaticDefaults() {
		Tooltip.SetDefault("10% Increased Movement Speed");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.rare = ItemRarityID.Orange;
			item.defense = 7;
			item.value = 30000;
		}
		
		public override void UpdateEquip(Player player) {
		player.moveSpeed += 0.10f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.ArqueriteBar>(), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
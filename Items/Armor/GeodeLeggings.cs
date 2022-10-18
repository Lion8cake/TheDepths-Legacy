using TheDepths.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using TheDepths.Items.Placeable;

namespace TheDepths.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class GeodeLeggings : ModItem
	{
		public override void SetStaticDefaults() {
		Tooltip.SetDefault("Incressed maximum amount of minions");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.rare = ItemRarityID.White;
			item.defense = 5;
			item.value = 4500;
		}
		
		public override void UpdateEquip(Player player) {
		player.maxMinions++;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.Geode>(), 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
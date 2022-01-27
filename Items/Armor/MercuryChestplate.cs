using TheDepths.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class MercuryChestplate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Mercury Chestplate");
			Tooltip.SetDefault("8% Increased Melee Damage");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.rare = ItemRarityID.Orange;
			item.defense = 8;
			item.value = 30000;
		}
		
		public override void UpdateEquip(Player player) {
		player.meleeDamage += 0.08f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.ArqueriteBar>(), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
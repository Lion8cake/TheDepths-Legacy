using TheDepths.Tiles;
using TheDepths.Buffs;
using TheDepths.Items.Placeable;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheDepths.Items.Accessories
{
	public class CrystalSkull : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Grants immunity to Mercury Poisoning");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.value = 27000;
			item.rare = ItemRarityID.Green;
			item.accessory = true;
			item.defense = 1;
			item.lifeRegen = 19;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
            player.buffImmune[ModContent.BuffType<MercuryPoisoning>()] = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.Quartz>(), 30);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheDepths.Items.Placeable;

namespace TheDepths.Items.Weapons
{
	public class DiamondArrow : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("3 bursts of crystals are shot out in random directions apon impact");
		}

		public override void SetDefaults() {
			item.damage = 12;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true; 
			item.knockBack = 1.5f;
			item.value = 80;
			item.rare = ItemRarityID.Orange;
			item.shoot = ModContent.ProjectileType<Projectiles.DiamondArrow>();
			item.shootSpeed = 7f;
			item.ammo = AmmoID.Arrow;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(40, 33);
			recipe.AddIngredient(ModContent.ItemType<DiamondDust>(), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 33);
			recipe.AddRecipe();
		}
	}
}

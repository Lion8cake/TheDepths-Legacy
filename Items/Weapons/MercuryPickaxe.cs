using TheDepths.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheDepths.Dusts;

namespace TheDepths.Items.Weapons
{
	public class MercuryPickaxe : ModItem
	{
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			item.damage = 15;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 5;
			item.useAnimation = 10;
			item.pick = 100;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 2;
			item.value = Item.sellPrice(silver: 54);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(10)) {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<MercurySparkleDust>());
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ArqueriteBar>(), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
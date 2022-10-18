using TheDepths.Dusts;
using TheDepths.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Items.Weapons
{
	public class Terminex : ModItem
	{
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			item.damage = 38;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 30;
			item.useAnimation = 30; 
			item.knockBack = 15;
			item.value = Item.buyPrice(gold: 27);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1; 
			item.autoReuse = true;
			item.crit = 4;
			item.useStyle = ItemUseStyleID.SwingThrow;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(3)) {
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<MercurySparkleDust>());
			}
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

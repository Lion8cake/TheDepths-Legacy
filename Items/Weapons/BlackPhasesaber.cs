using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheDepths.Items.Weapons
{
	public class BlackPhasesaber : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(3764);
			item.damage = 41;
			item.melee = true;
			item.width = 40;
			item.height = 40;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			Lighting.AddLight(player.itemLocation + new Vector2(6f + player.velocity.X, 14f), 0.3f, 0.275f, 0.3f);
		}
	    
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrystalShard, 50);
			recipe.AddIngredient(ModContent.ItemType<Items.Weapons.BlackPhaseblade>(), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

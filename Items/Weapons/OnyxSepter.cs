using TheDepths.Projectiles;
using TheDepths.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Items.Weapons
{
	public class OnyxSepter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Onyx Septer");
		}
	
		public override void SetDefaults()
		{
			item.damage = 68;
			item.magic = true;
			item.mana = 6;
			item.width = 30;
			item.height = 30;
			item.useTime = 32;
			item.useAnimation = 32;
			item.autoReuse = true;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 0, 80);
			item.rare = 4;
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("OnyxBolt");
			item.shootSpeed = 7.5f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.ArqueriteBar>(), 10);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.Geode>(), 6);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.Onyx>(), 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
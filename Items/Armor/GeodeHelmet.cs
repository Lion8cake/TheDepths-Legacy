using TheDepths.Tiles;
using TheDepths.Projectiles.GeodeSetBonus;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using TheDepths.Items.Placeable;

namespace TheDepths.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class GeodeHelmet : ModItem
	{ 
	    
		public int timer;
		
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

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<GeodeChestplate>() && legs.type == ModContent.ItemType<GeodeLeggings>();
		}

		public override void UpdateArmorSet(Player player) {
		player.setBonus = "Summons 4 Geode Crystals that will deal 20 damage";
			timer++;
		if (player.ownedProjectileCounts[mod.ProjectileType("GeodeCrystalSummon")] < 1 && timer > 20)
		{
			for (int i = 0; i < 6; i++)
			{
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("GeodeCrystalSummon"), 15, 8f, player.whoAmI, i);
			}
			timer = 0;
		}
		for (int j = 0; j < 1000; j++)
		{
			Projectile projectile = Main.projectile[j];
			if (projectile.active && projectile.owner == player.whoAmI && projectile.type == mod.ProjectileType("GeodeCrystalSummon"))
			{
				projectile.timeLeft = 2;
			}
		}
		}
		
		public override bool DrawHead() {
			return false;
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
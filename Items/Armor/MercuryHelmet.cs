using TheDepths.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheDepths.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class MercuryHelmet : ModItem
	{
		public override void SetStaticDefaults() {
		Tooltip.SetDefault("4% Increased Melee Critical Strike Chance");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.rare = ItemRarityID.Orange;
			item.defense = 7;
			item.value = 45000;
		}
		
		public override void UpdateEquip(Player player) {
		player.meleeCrit += 4;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<MercuryChestplate>() && legs.type == ModContent.ItemType<MercuryGreaves>();
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "3 Defence";
			player.statDefense += 3;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.ArqueriteBar>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
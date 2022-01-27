using TheDepths.Tiles;
using TheDepths.Buffs;
using TheDepths.Items.Placeable;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheDepths.Items.Accessories
{
[AutoloadEquip(new EquipType[] { EquipType.Shoes })]
	public class SilverSlippers : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Provides the ability to walk on water\nGrants immunity to Mercury Poisoning and Boiling");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.value = 500000;
			item.rare = ItemRarityID.Lime;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
            player.buffImmune[ModContent.BuffType<MercuryPoisoning>()] = true;
			player.waterWalk = true;
			player.buffImmune[ModContent.BuffType<MercuryBoiling>()] = true;
			player.fireWalk = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Accessories.AmalgamAmulet>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Items.Accessories.CrystalWaterWalkingBoots>(), 1);
			recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
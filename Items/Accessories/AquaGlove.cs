using TheDepths.Tiles;
using TheDepths.Buffs;
using TheDepths.Items.Placeable;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheDepths.Items.Accessories
{
	[AutoloadEquip(new EquipType[]
	{
		EquipType.HandsOn,
		EquipType.HandsOff
	})]
	public class AquaGlove : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases Melee knockback and inflicts freezing water on attack\n9% Melee Speed and Damage");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.value = 300000;
			item.rare = ItemRarityID.Lime;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.meleeDamage += 0.09f;
			player.meleeSpeed += 0.09f;
			player.kbGlove = true;
            player.GetModPlayer<TheDepthsPlayer>().aStone = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MechanicalGlove, 1);
			recipe.AddIngredient(ModContent.ItemType<Items.Accessories.AquaStone>(), 1);
			recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
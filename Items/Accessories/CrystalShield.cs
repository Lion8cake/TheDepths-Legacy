using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using TheDepths.Buffs;

namespace TheDepths.Items.Accessories
{
[AutoloadEquip(new EquipType[] { EquipType.Shield })]
	class CrystalShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Shield");
			Tooltip.SetDefault("Increases damage redusction by 10% and provides knockback and mercury poisoning immunity");
		}

		public override void SetDefaults()
		{
			item.rare = ItemRarityID.LightRed;
			item.width = 20;
			item.value = 100000;
			item.accessory = true;
			item.height = 20;
			item.defense = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.noKnockback = true;
			player.buffImmune[ModContent.BuffType<MercuryPoisoning>()] = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Accessories.CrystalSkull>(), 1);
			recipe.AddIngredient(ItemID.CobaltShield, 1);
			recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
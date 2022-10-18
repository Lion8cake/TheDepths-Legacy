using TheDepths.Tiles;
using TheDepths.Buffs;
using TheDepths.Items.Placeable;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheDepths.Items
{
	public class ShadowShrub : ModItem
	{
		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.value = 100;
			item.rare = ItemRarityID.White;
			item.maxStack = 99;
		}
	}
}
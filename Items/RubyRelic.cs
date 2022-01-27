using TheDepths.Tiles;
using TheDepths.Buffs;
using TheDepths.Items.Placeable;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheDepths.Items
{
	public class RubyRelic : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Do you hear something?'");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.value = 1000;
			item.rare = ItemRarityID.White;
			item.accessory = true;
		}
	}
}
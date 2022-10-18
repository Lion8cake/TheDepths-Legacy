using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Items.Placeable
{
	public class QuartzTable : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quartz Table");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 22;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 0;
			item.createTile = mod.TileType("QuartzTable");
		}
	}
}

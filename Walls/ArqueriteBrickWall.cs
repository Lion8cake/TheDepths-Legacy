using Microsoft.Xna.Framework;
using TheDepths.Items.Placeable;
using TheDepths.Dusts;
using Terraria;
using Terraria.ModLoader;

namespace TheDepths.Walls
{
	public class ArqueriteBrickWall : ModWall
	{
		public override void SetDefaults() {
			Main.wallHouse[Type] = true;
			dustType = ModContent.DustType<ArqueriteDust>();
			drop = ModContent.ItemType<Items.Placeable.ArqueriteBrickWall>();
			AddMapEntry(new Color(38, 45, 55));
		}
		
		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}
	}
}
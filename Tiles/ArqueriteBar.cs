using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TheDepths.Tiles
{
	public class ArqueriteBar : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileShine[Type] = 1100;
			Main.tileSolid[Type] = true;
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(Type);
			dustType = mod.DustType("ArqueriteDust");

			AddMapEntry(new Color(71, 84, 105), Language.GetText("MapObject.MetalBar"));
		}

		public override bool Drop(int i, int j)
		{
			Tile t = Main.tile[i, j];
			int style = t.frameX / 18;
			if (style == 0)
			{
				Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Placeable.ArqueriteBar>());
			}
			return base.Drop(i, j);
		}
	}
}
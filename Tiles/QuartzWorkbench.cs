using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TheDepths.Tiles
{
	public class QuartzWorkbench : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
			TileObjectData.newTile.CoordinateHeights = new int[]{ 18 };
			TileObjectData.addTile(Type);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Workbench");
			disableSmartCursor = true;
			adjTiles = new int[]{ TileID.WorkBenches };
			AddMapEntry(new Color(255, 255, 255), name);
			dustType = mod.DustType("QuartzCrystals");
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("QuartzWorkbench"));
		}
	}
}
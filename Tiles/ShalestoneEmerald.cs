using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Tiles
{
	public class ShalestoneEmerald : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			drop = ItemID.Emerald;
			dustType = mod.DustType("ShaleDust");
			AddMapEntry(new Color(11, 147, 34));
			Main.tileMerge[Type][mod.TileType("ShaleBlock")] = true;
			Main.tileMerge[Type][mod.TileType("Shalestone")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneDiamond")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneAmethyst")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneRuby")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneSapphire")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneTopaz")] = true;
			Main.tileMerge[Type][mod.TileType("OnyxShalestone")] = true;
			
			soundType = SoundID.Tink;
			soundStyle = 1;
			minPick = 65;
		}

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}
	}
}
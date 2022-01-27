using Microsoft.Xna.Framework;
using Terraria;
using TheDepths.Buffs;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Tiles
{
	public class OnyxShalestone : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			AddMapEntry(new Color(0, 0, 0));
			Main.tileMerge[Type][mod.TileType("ShaleBlock")] = true;
			Main.tileMerge[Type][mod.TileType("Shalestone")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneAmethyst")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneDiamond")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneEmerald")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneRuby")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneSapphire")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneTopaz")] = true;
			dustType = mod.DustType("ShaleDust");

			drop = ModContent.ItemType<Items.Placeable.Onyx>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			mineResist = 2f;
			minPick = 110;
		}
	}
}
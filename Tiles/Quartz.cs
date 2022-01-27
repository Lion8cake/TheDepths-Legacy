using Microsoft.Xna.Framework;
using Terraria;
using TheDepths.Buffs;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Tiles
{
	public class Quartz : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 975;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileMerge[Type][mod.TileType("ArqueriteOre")] = true;
			Main.tileMerge[Type][mod.TileType("Shalestone")] = true;
			Main.tileMerge[Type][mod.TileType("ShaleBlock")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneAmethyst")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneDiamond")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneEmerald")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneRuby")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneSapphire")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneTopaz")] = true;
			Main.tileMerge[Type][mod.TileType("OnyxShalestone")] = true;
			dustType = mod.DustType("QuartzCrystals");

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Quartz");
			AddMapEntry(new Color(255, 255, 255), name);

			drop = ModContent.ItemType<Items.Placeable.Quartz>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			mineResist = 2f;
			minPick = 65;
		}
	}
}
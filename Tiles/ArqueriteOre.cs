using Microsoft.Xna.Framework;
using Terraria;
using TheDepths.Buffs;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Tiles
{
	public class ArqueriteOre : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 500;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 975;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			dustType = mod.DustType("ArqueriteDust");
			Main.tileMerge[Type][mod.TileType("Shalestone")] = true;
			Main.tileMerge[Type][mod.TileType("Quartz")] = true;
			Main.tileMerge[Type][mod.TileType("ShaleBlock")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneAmethyst")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneDiamond")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneEmerald")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneRuby")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneSapphire")] = true;
			Main.tileMerge[Type][mod.TileType("ShalestoneTopaz")] = true;
			Main.tileMerge[Type][mod.TileType("OnyxShalestone")] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Arquerite Ore");
			AddMapEntry(new Color(119, 134, 162), name);

			drop = ModContent.ItemType<Items.Placeable.ArqueriteOre>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			mineResist = 2f;
			minPick = 65;
		}
		
		public override void NearbyEffects(int i, int j, bool closer)
		{
			Player player = Main.LocalPlayer;
			if ((int)Vector2.Distance(player.Center / 16f, new Vector2((float)i, (float)j)) <= 1)
			{
				player.AddBuff(ModContent.BuffType<MercuryPoisoning>(), Main.rand.Next(10, 20));
			}
		}
	}
}
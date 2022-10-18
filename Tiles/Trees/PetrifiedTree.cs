using TheDepths.Dusts;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace TheDepths.Tiles.Trees
{
	public class PetrifiedTree : ModTree
	{
		private Mod mod => ModLoader.GetMod("TheDepths");

		public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
	{
		frame = (i + j * j) % 3;
		return ModContent.GetTexture("TheDepths/Tiles/Trees/PetrifiedTree_Tops");
	}

	public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
	{
		return ModContent.GetTexture("TheDepths/Tiles/Trees/PetrifiedTree_Branches");
	}

	public override Texture2D GetTexture()
	{
		return ModContent.GetTexture("TheDepths/Tiles/Trees/PetrifiedTree");
	}

	public override int DropWood()
	{
		return ModContent.ItemType<Items.Placeable.PetrifiedWood>();
	}

	public override int CreateDust()
	{
		return ModContent.DustType<PetrifiedWoodDust>();
	}

	public override int GrowthFXGore()
	{
		return -1;
	}
	}
} 
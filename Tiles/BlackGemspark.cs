using TheDepths.Items.Placeable;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;
using Microsoft.Xna.Framework.Graphics;

namespace TheDepths.Tiles
{
public class BlackGemspark : ModTile
{
	public override void SetDefaults()
	{
		Main.tileLighted[Type] = true;
		Main.tileSolid[Type] = true;
		dustType = mod.DustType("BlackGemsparkDust");
		drop = mod.ItemType("BlackGemsparkBlock");
		AddMapEntry(new Color(22, 19, 28));
		drop = ModContent.ItemType<Items.Placeable.BlackGemspark>();
	}

	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		r = 0.65f;
		g = 0.71f;
		b = 0.92f;
	}

	public override void ChangeWaterfallStyle(ref int style)
	{
		style = mod.GetWaterfallStyleSlot("BlackWaterfallStyle");
	}

	public override void HitWire(int i, int j)
	{
		Tile tileSafely = Framing.GetTileSafely(i, j);
		if (!tileSafely.actuator())
		{
			tileSafely.type = (ushort)ModContent.TileType<BlackGemsparkOff>();
			WorldGen.SquareTileFrame(i, j);
			NetMessage.SendTileSquare(-1, i, j, 1);
		}
	}
	
	public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Texture2D texture;
            if (Main.canDrawColorTile(i, j))
            {
                texture = Main.tileAltTexture[Type, (int)tile.color()];
            }
            else
            {
                texture = Main.tileTexture[Type];
            }
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
        }
}
}
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TheDepths.Tiles
{
    public class LargeCrystal : ModTile
    {
        public override void SetDefaults()
        {
		    ModTranslation name = CreateMapEntryName();
            name.SetDefault("Large Crystal");
            AddMapEntry(new Color(163, 66, 14), name);
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16 };
            TileObjectData.addTile(Type);
			Main.tileFrameImportant[Type] = true;
	    }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 64, 32, ModContent.ItemType<Items.Placeable.LargeCrystal>());
        }
    }
}

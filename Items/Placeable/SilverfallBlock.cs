using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TheDepths.Items.Placeable
{
    public class SilverfallBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silverfall Block");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LavafallBlock);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.createTile = TileType<Tiles.SilverfallBlock>();
        }
    }
}

using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TheDepths.Items.Placeable
{
    public class SilverfallWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silverfall Wall");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LavafallWall);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.createWall = WallType<Walls.SilverfallWall>();
        }
    }
}

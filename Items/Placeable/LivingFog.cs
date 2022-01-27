using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TheDepths.Items.Placeable
{
    public class LivingFog : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Living Fog Block");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.createTile = TileType<Tiles.LivingFog>();
        }

        public override void PostUpdate()
        {
            float BASE = 1 / 255;
            float r = BASE * 185;
            float g = BASE * 197;
            float b = BASE * 200;
            Lighting.AddLight((int)(item.position.X + item.width / 2 / 16), (int)(item.position.Y + item.height / 2 / 16), r, g, b);
        }
    }
}

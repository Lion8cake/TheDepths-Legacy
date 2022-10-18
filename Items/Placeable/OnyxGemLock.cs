using Terraria.ID;
using Terraria.ModLoader;
using TheDepths.Tiles;

namespace TheDepths.Items.Placeable
{
    public class OnyxGemLock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Onyx Gem Lock");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.GemLockRuby);
            item.createTile = ModContent.TileType<GemlockTile>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 5);
            recipe.AddIngredient(ItemID.StoneBlock, 10);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

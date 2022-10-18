using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using TheDepths.Items.Placeable;

namespace TheDepths.Items
{
    public class OnyxHook : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.SapphireHook);
            item.shootSpeed = 18f;
            item.shoot = mod.ProjectileType("OnyxHook");
        }
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

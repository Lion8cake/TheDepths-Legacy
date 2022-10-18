using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Items
{
	public class SilverSpherePotion : ModItem
	{
        public override void SetStaticDefaults()
        {
		    DisplayName.SetDefault("Silver Sphere Potion");
            Tooltip.SetDefault("Four Silver Spheres summon around you");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = 1000;
            item.buffType = ModContent.BuffType<Buffs.SilverSphereBuff>();
            item.buffTime = 14400;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(ItemID.FlarefinKoi, 1);
			recipe.AddIngredient(ItemID.Obsidifish, 2);
			recipe.AddIngredient(ModContent.ItemType<Items.ShadowShrub>(), 1);
			recipe.AddTile(13);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}

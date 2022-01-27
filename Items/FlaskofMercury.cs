using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Items
{
	public class FlaskofMercury : ModItem
	{
        public override void SetStaticDefaults()
        {
		    DisplayName.SetDefault("Flask of Mercury");
            Tooltip.SetDefault("Melee attacks boils enemies with mercury");
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
            item.rare = ItemRarityID.LightRed;
            item.value = 2500;
            item.buffType = ModContent.BuffType<Buffs.FlaskofMercury>();
            item.buffTime = 72000;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.ArqueriteOre>(), 3);
			recipe.AddTile(TileID.ImbuingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}

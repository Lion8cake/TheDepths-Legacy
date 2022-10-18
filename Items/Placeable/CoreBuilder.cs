using Terraria.ID;
using Terraria.ModLoader;
using TheDepths.Items;
using TheDepths.Items.Weapons;
using TheDepths.Items.Placeable;
using TheDepths.Items.Armor;
using TheDepths.Items.Accessories;
using TheDepths.Items.Banners;
using TheDepths.Tiles;

namespace TheDepths.Items.Placeable
{
	public class CoreBuilder : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Core Builder");
            Tooltip.SetDefault("Allows you to convert hell materials into their depths alternatives and vice versa\n" +
                "'A legendary forge that is rumored to be the reason how the core of each world is created'");
        }

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 99;
			item.value = 3000;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.CoreBuilderTile>();
			item.placeStyle = 0;
			item.rare = ItemRarityID.Green;
		}
		
		public override void AddRecipes()
        {
		    //The Item recipe
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AshBlock, 50);
            recipe.AddIngredient(221, 1);
            recipe.AddIngredient(175, 10);
            recipe.SetResult(this);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ShaleBlock", 50);
            recipe.AddIngredient(null, "Gemforge", 1);
            recipe.AddIngredient(null, "ArqueriteBar", 10);
            recipe.SetResult(this);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
			
			//Ash to Shale/shalestone
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AshBlock, 1);
			recipe.SetResult(null, "ShaleBlock", 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ShaleBlock", 1);
			recipe.SetResult(ItemID.AshBlock, 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AshBlock, 1);
			recipe.SetResult(null, "Shalestone", 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Shalestone", 1);
			recipe.SetResult(ItemID.AshBlock, 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			//Hellstone to Arqurerite and their bars
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(175, 1);
			recipe.SetResult(null, "ArqueriteBar", 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ArqueriteBar", 1);
			recipe.SetResult(175, 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(174, 1);
			recipe.SetResult(null, "ArqueriteOre", 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ArqueriteOre", 1);
			recipe.SetResult(174, 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			//Obsidian Brick to Quartz Brick. Same with Hellstone and Arqruerite. And the walls yes
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ObsidianBrick, 1);
			recipe.SetResult(null, "QuartzBricks", 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "QuartzBricks", 1);
			recipe.SetResult(ItemID.ObsidianBrick, 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBrick, 1);
			recipe.SetResult(null, "ArqueriteBricks", 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ArqueriteBricks", 1);
			recipe.SetResult(ItemID.HellstoneBrick, 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ObsidianBrickWall, 1);
			recipe.SetResult(null, "QuartzBrickWall", 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "QuartzBrickWall", 1);
			recipe.SetResult(ItemID.ObsidianBrickWall, 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBrickWall, 1);
			recipe.SetResult(null, "ArqueriteBrickWall", 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ArqueriteBrickWall", 1);
			recipe.SetResult(ItemID.HellstoneBrickWall, 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			//Voodoo Doll and Relic 
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GuideVoodooDoll, 1);
			recipe.SetResult(null, "RubyRelic", 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RubyRelic", 1);
			recipe.SetResult(ItemID.GuideVoodooDoll, 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			//FireBlossom And Shadow Shrub. W their seeds
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Fireblossom, 1);
			recipe.SetResult(null, "ShadowShrub", 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ShadowShrub", 1);
			recipe.SetResult(ItemID.Fireblossom, 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(312, 1);
			recipe.SetResult(null, "ShadowShrubSeeds", 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ShadowShrubSeeds", 1);
			recipe.SetResult(312, 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			//Obsidian to Quartz
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Obsidian, 1);
			recipe.SetResult(null, "Quartz", 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Quartz", 1);
			recipe.SetResult(ItemID.Obsidian, 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			//Living Fire to Living Fog
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(2701, 1);
			recipe.SetResult(null, "LivingFog", 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LivingFog", 1);
			recipe.SetResult(2701, 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			//Lavafall to Quick Silverfall. With Walls
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(2694, 1);
			recipe.SetResult(null, "SilverfallBlock", 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SilverfallBlock", 1);
			recipe.SetResult(2694, 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(2170, 1);
			recipe.SetResult(null, "SilverfallWall", 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SilverfallWall", 1);
			recipe.SetResult(2170, 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			//Demonite Brick and Crimtain Brick to Shadow Brick
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBrick, 1);
			recipe.SetResult(null, "ShadowBrick", 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ShadowBrick", 1);
			recipe.SetResult(ItemID.DemoniteBrick, 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBrick, 1);
			recipe.SetResult(null, "ShadowBrick", 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ShadowBrick", 1);
			recipe.SetResult(ItemID.CrimtaneBrick, 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			//Plumber Hat and Purple Plumber hat
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(244, 1);
			recipe.SetResult(null, "PurplePlumbersHat", 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "PurplePlumbersHat", 1);
			recipe.SetResult(244, 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			//Hellforge to Gemforge
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Hellforge, 1);
			recipe.SetResult(null, "Gemforge", 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Gemforge", 1);
			recipe.SetResult(ItemID.Hellforge, 1);
            recipe.AddTile(null, "CoreBuilderTile");
			recipe.AddRecipe();
		}
	}
}

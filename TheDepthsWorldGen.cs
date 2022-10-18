using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ModLoader;
using Terraria.World.Generation;
using TheDepths.Tiles;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using System;
using Terraria.GameContent.Biomes;
using TheDepths.Walls;
using Terraria.ID;

namespace TheDepths
{
    /// <summary>
    /// WHOLE SHIT HERE WAS MADE BY Develassper. aka "basically, i am little fox"
    /// </summary>
    public class TheDepthsWorldGen : ModWorld
    {
		public enum UnderworldVariant
        {
            underworld,
            depths,
            random
        }
		
		public static UnderworldVariant underworldMenuSelection = UnderworldVariant.random;
		
		public override void PreWorldGen()
        {
            if (underworldMenuSelection == UnderworldVariant.random)
            {
                underworldMenuSelection = (UnderworldVariant)WorldGen.genRand.Next(2);
            }
			depthsorHell = underworldMenuSelection == UnderworldVariant.depths;
        }
		
	    public static bool depthsorHell;

        public override void Initialize()
        {
            depthsorHell = false;
        }
	
        public override void ModifyWorldGenTasks(List<GenPass> list, ref float totalWeight)
        {
            if (depthsorHell)
            {
                int index2 = list.FindIndex(genpass => genpass.Name.Equals("Underworld"));
                int index3 = list.FindIndex(genpass => genpass.Name.Equals("Hellforge"));
if (index2 != -1) {
                list.Insert(index2 + 1, new PassLegacy("The Depths: Underworld Alt", new WorldGenLegacyMethod(Depths)));
                list.RemoveAt(index2);
}
if (index3 != -1) {
                list.Insert(index3 + 1, new PassLegacy("The Depths: Hellforge Alt", new WorldGenLegacyMethod(Gemforge)));
                list.Insert(index3 + 2, new PassLegacy("The Depths: Trees", new WorldGenLegacyMethod(TreeGen)));
                list.RemoveAt(index3);
}
            }

            if (Main.rand.NextBool(int.MaxValue))
            {
                list.Add(new PassLegacy("The Depths: Removing Lava", new WorldGenLegacyMethod(LavaRemoval)));
            }
        }

        private void LavaRemoval(GenerationProgress progress)
        {
            progress.Message = "Removing lava...";
            progress.Set(0f);
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = 0; j < Main.maxTilesY; j++)
                {
                    if (Main.tile[i, j].liquid > 0)
                    {
                        if (Main.tile[i, j].honey())
                            Main.tile[i, j].honey(false);
                        Main.tile[i, j].lava(true);
                    }
                }
            }
            progress.Set(0.5f);
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = 0; j < Main.maxTilesY; j++)
                {
                    if (Main.tile[i, j].type == TileID.HoneyDrip || Main.tile[i, j].type == TileID.WaterDrip)
                    {
                        Main.tile[i, j].type = TileID.LavaDrip;
                    }

                    List<int> toAir = new List<int> { TileID.Cactus, TileID.CactusBlock, TileID.Plants, TileID.Plants2, TileID.
                        CorruptPlants, TileID.HallowedPlants, TileID.HallowedPlants2, TileID.JunglePlants, TileID.JunglePlants2,
                        TileID.MushroomPlants, TileID.Sunflower, TileID.Pots, TileID.Vines, TileID.CrimsonVines, TileID.JungleVines,
                        TileID.VineFlowers, TileID.Banners, 165, 185, 184, 186, 187, 227, 233, TileID.Pumpkins, TileID.MinecartTrack,
                        324, TileID.HoneyDrip };
                    List<int> blockToArqueriteBrick = new List<int> { TileID.Marble, TileID.MarbleBlock, TileID.Granite, TileID.
                        GraniteBlock, TileID.LihzahrdBrick, TileID.BlueDungeonBrick, TileID.GreenDungeonBrick, TileID.PinkDungeonBrick,
                        TileID.HoneyBlock, TileID.CrispyHoneyBlock, TileID.BeeHive, TileID.LivingMahoganyLeaves, TileID.LeafBlock,
                        TileID.MushroomBlock, TileID.Hive, TileID.SandstoneBrick, TileID.HellstoneBrick, TileID.Cloud };
                    List<int> blockToArqueriteOre = new List<int> { TileID.BlueMoss, TileID.BrownMoss, TileID.GreenMoss, TileID.LavaMoss,
                        TileID.LongMoss, TileID.PurpleMoss, TileID.RedMoss, TileID.Hellstone, TileID.RainCloud };
                    List<int> blockToPetrifiedWood = new List<int> { TileID.WoodBlock, TileID.WoodenBeam, TileID.RichMahogany };
                    List<int> blockToQuartz = new List<int> { TileID.Copper, TileID.Tin, TileID.Iron, TileID.Lead, TileID.Gold, TileID.
                        Platinum, TileID.Demonite, TileID.Crimtane, TileID.FossilOre, TileID.DesertFossil, TileID.LivingMahogany,
                        TileID.LivingWood, TileID.Sunplate, TileID.ClayBlock, TileID.BreakableIce };
                    List<int> blockToShaleblock = new List<int> { TileID.Dirt, TileID.Grass, TileID.FleshGrass, TileID.CorruptGrass,
                        TileID.HallowedGrass, TileID.JungleGrass, TileID.MushroomGrass, TileID.SnowBlock, TileID.Sand, TileID.
                        CrimsonSandstone, TileID.CorruptSandstone, TileID.Sandstone, TileID.Crimsand, TileID.Ebonsand};
                    List<int> blockToShalestone = new List<int> { TileID.Mud, TileID.Stone, TileID.ActiveStoneBlock, TileID.
                        InactiveStoneBlock, TileID.IceBlock, TileID.Crimstone, TileID.Ebonstone, TileID.HardenedSand, TileID.
                        CorruptHardenedSand, TileID.CrimsonHardenedSand, TileID.CorruptIce, TileID.FleshIce, };
                    if (depthsorHell)
                    {
                        if (toAir.Contains(Main.tile[i, j].type))
                        {
                            Main.tile[i, j].active(false);
                        }
                        if (blockToArqueriteBrick.Contains(Main.tile[i, j].type))
                        {
                            Main.tile[i, j].type = (ushort)TileType<ArqueriteBricks>();
                        }
                        if (blockToArqueriteOre.Contains(Main.tile[i, j].type))
                        {
                            Main.tile[i, j].type = (ushort)TileType<ArqueriteOre>();
                        }
                        if (blockToPetrifiedWood.Contains(Main.tile[i, j].type))
                        {
                            Main.tile[i, j].type = (ushort)TileType<PetrifiedWood>();
                        }
                        if (blockToQuartz.Contains(Main.tile[i, j].type))
                        {
                            Main.tile[i, j].type = (ushort)TileType<Quartz>();
                        }
                        if (blockToShaleblock.Contains(Main.tile[i, j].type))
                        {
                            Main.tile[i, j].type = (ushort)TileType<ShaleBlock>();
                        }
                        if (blockToShalestone.Contains(Main.tile[i, j].type))
                        {
                            Main.tile[i, j].type = (ushort)TileType<Shalestone>();
                        }

                        if (Main.tile[i, j].type == TileID.Amethyst)
                            Main.tile[i, j].type = (ushort)TileType<ShalestoneAmethyst>();
                        else if (Main.tile[i, j].type == TileID.Topaz)
                            Main.tile[i, j].type = (ushort)TileType<ShalestoneTopaz>();
                        else if (Main.tile[i, j].type == TileID.Sapphire)
                            Main.tile[i, j].type = (ushort)TileType<ShalestoneSapphire>();
                        else if (Main.tile[i, j].type == TileID.Emerald)
                            Main.tile[i, j].type = (ushort)TileType<ShalestoneEmerald>();
                        else if (Main.tile[i, j].type == TileID.Ruby)
                            Main.tile[i, j].type = (ushort)TileType<ShalestoneRuby>();
                        else if (Main.tile[i, j].type == TileID.Diamond)
                            Main.tile[i, j].type = (ushort)TileType<ShalestoneDiamond>();

                        if (Main.tile[i, j].type == TileID.Torches)
                            Main.tile[i, j].type = (ushort)TileType<BlackTorch>();
                        if (Main.tile[i, j].type == TileID.Coral)
                            Main.tile[i, j].type = (ushort)TileType<Ember>();

                        if (Main.tile[i, j].wall > 0)
                        {
                            Main.tile[i, j].wall = (ushort)WallType<ArqueriteBrickWallUnsafe>();
                        }
                    }
                    else
                    {
                        if (toAir.Contains(Main.tile[i, j].type))
                        {
                            Main.tile[i, j].active(false);
                        }
                        if (blockToArqueriteBrick.Contains(Main.tile[i, j].type))
                        {
                            Main.tile[i, j].type = TileID.HellstoneBrick;
                        }
                        if (blockToArqueriteOre.Contains(Main.tile[i, j].type))
                        {
                            Main.tile[i, j].type = TileID.Hellstone;
                        }
                        if (blockToPetrifiedWood.Contains(Main.tile[i, j].type))
                        {
                            Main.tile[i, j].type = TileID.LivingFire;
                        }
                        if (blockToQuartz.Contains(Main.tile[i, j].type))
                        {
                            Main.tile[i, j].type = TileID.HellstoneBrick;
                        }
                        if (blockToShaleblock.Contains(Main.tile[i, j].type))
                        {
                            Main.tile[i, j].type = TileID.Ash;
                        }
                        if (blockToShalestone.Contains(Main.tile[i, j].type))
                        {
                            Main.tile[i, j].type = TileID.ObsidianBrick;
                        }

                        if (Main.tile[i, j].type == TileID.Coral)
                            Main.tile[i, j].type = TileID.LivingDemonFire;

                        if (Main.tile[i, j].wall > 0)
                        {
                            Main.tile[i, j].wall = WallID.HellstoneBrickUnsafe;
                        }
                    }
                }
            }
            progress.Set(1f);
        }

        private void Gemforge(GenerationProgress progress)
        {
            progress.Message = "Placing gemforges";
            for (int index1 = 0; index1 < Main.maxTilesX / 200; ++index1)
            {
                float num2 = index1 / (Main.maxTilesX / 200);
                progress.Set(num2);
                bool flag = false;
                int num3 = 0;
                while (!flag)
                {
                    int i = WorldGen.genRand.Next(1, Main.maxTilesX);
                    int index2 = WorldGen.genRand.Next(Main.maxTilesY - 250, Main.maxTilesY - 30);
                    try
                    {
                        if (Main.tile[i, index2].wall != WallType<ArqueriteBrickWallUnsafe>())
                        {
                            if (Main.tile[i, index2].wall != WallType<QuartzBrickWallUnsafe>())
                                continue;
                        }
                        while (!Main.tile[i, index2].active() && index2 < Main.maxTilesY - 20)
                            ++index2;
                        int j = index2 - 1;
                        WorldGen.PlaceTile(i, j, TileType<Gemforge>());
                        if (Main.tile[i, j].type == TileType<Gemforge>())
                        {
                            flag = true;
                        }
                        else
                        {
                            ++num3;
                            if (num3 >= 10000)
                                flag = true;
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        private static void Depths(GenerationProgress progress)
        {
            {
                progress.Message = "Creating depths";
                progress.Set(0.0f);
                int num1 = Main.maxTilesY - WorldGen.genRand.Next(150, 190);
                for (int index1 = 0; index1 < Main.maxTilesX; ++index1)
                {
                    num1 += WorldGen.genRand.Next(-3, 4);
                    if (num1 < Main.maxTilesY - 190)
                        num1 = Main.maxTilesY - 190;
                    if (num1 > Main.maxTilesY - 160)
                        num1 = Main.maxTilesY - 160;
                    for (int index2 = num1 - 20 - WorldGen.genRand.Next(3); index2 < Main.maxTilesY; ++index2)
                    {
                        if (index2 >= num1)
                        {
                            Main.tile[index1, index2].active(false);
                            Main.tile[index1, index2].lava(false);
                            Main.tile[index1, index2].liquid = 0;
                        }
                        else
                            Main.tile[index1, index2].type = (ushort)TileType<ShaleBlock>();
                    }
                }
                int num2 = Main.maxTilesY - WorldGen.genRand.Next(40, 70);
                for (int index1 = 10; index1 < Main.maxTilesX - 10; ++index1)
                {
                    num2 += WorldGen.genRand.Next(-10, 11);
                    if (num2 > Main.maxTilesY - 60)
                        num2 = Main.maxTilesY - 60;
                    if (num2 < Main.maxTilesY - 100)
                        num2 = Main.maxTilesY - 120;
                    for (int index2 = num2; index2 < Main.maxTilesY - 10; ++index2)
                    {
                        if (!Main.tile[index1, index2].active())
                        {
                            Main.tile[index1, index2].lava(true);
                            Main.tile[index1, index2].liquid = byte.MaxValue;
                        }
                    }
                }
                for (int index1 = 0; index1 < Main.maxTilesX; ++index1)
                {
                    if (WorldGen.genRand.Next(50) == 0)
                    {
                        int index2 = Main.maxTilesY - 65;
                        while (!Main.tile[index1, index2].active() && index2 > Main.maxTilesY - 135)
                            --index2;
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), index2 + WorldGen.genRand.Next(20, 50), WorldGen.genRand.Next(15, 20), 1000, TileType<ShaleBlock>(), true, 0.0f, WorldGen.genRand.Next(1, 3), true, true);
                    }
                }
                Liquid.QuickWater(-2, -1, -1);
                for (int i = 0; i < Main.maxTilesX; ++i)
                {
                    float num3 = i / (Main.maxTilesX - 1);
                    progress.Set((float)(num3 / 2.0 + 0.5));
                    if (WorldGen.genRand.Next(13) == 0)
                    {
                        int index = Main.maxTilesY - 65;
                        while ((Main.tile[i, index].liquid > 0 || Main.tile[i, index].active()) && index > Main.maxTilesY - 140)
                            --index;
                        WorldGen.TileRunner(i, index - WorldGen.genRand.Next(2, 5), WorldGen.genRand.Next(5, 30), 1000, TileType<ShaleBlock>(), true, 0.0f, WorldGen.genRand.Next(1, 3), true, true);
                        float num4 = WorldGen.genRand.Next(1, 3);
                        if (WorldGen.genRand.Next(3) == 0)
                            num4 *= 0.5f;
                        if (WorldGen.genRand.Next(2) == 0)
                            WorldGen.TileRunner(i, index - WorldGen.genRand.Next(2, 5), (int)(WorldGen.genRand.Next(5, 15) * (double)num4), (int)(WorldGen.genRand.Next(10, 15) * (double)num4), TileType<ShaleBlock>(), true, 1f, 0.3f, false, true);
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            float num5 = WorldGen.genRand.Next(1, 3);
                            WorldGen.TileRunner(i, index - WorldGen.genRand.Next(2, 5), (int)(WorldGen.genRand.Next(5, 15) * (double)num5), (int)(WorldGen.genRand.Next(10, 15) * (double)num5), TileType<ShaleBlock>(), true, -1f, 0.3f, false, true);
                        }
                        WorldGen.TileRunner(i + WorldGen.genRand.Next(-10, 10), index + WorldGen.genRand.Next(-10, 10), WorldGen.genRand.Next(5, 15), WorldGen.genRand.Next(5, 10), -2, false, WorldGen.genRand.Next(-1, 3), WorldGen.genRand.Next(-1, 3), false, true);
                        if (WorldGen.genRand.Next(3) == 0)
                            WorldGen.TileRunner(i + WorldGen.genRand.Next(-10, 10), index + WorldGen.genRand.Next(-10, 10), WorldGen.genRand.Next(10, 30), WorldGen.genRand.Next(10, 20), -2, false, WorldGen.genRand.Next(-1, 3), WorldGen.genRand.Next(-1, 3), false, true);
                        if (WorldGen.genRand.Next(5) == 0)
                            WorldGen.TileRunner(i + WorldGen.genRand.Next(-15, 15), index + WorldGen.genRand.Next(-15, 10), WorldGen.genRand.Next(15, 30), WorldGen.genRand.Next(5, 20), -2, false, WorldGen.genRand.Next(-1, 3), WorldGen.genRand.Next(-1, 3), false, true);
                    }
                }
                for (int index = 0; index < Main.maxTilesX; ++index)
                    WorldGen.TileRunner(WorldGen.genRand.Next(20, Main.maxTilesX - 20), WorldGen.genRand.Next(Main.maxTilesY - 180, Main.maxTilesY - 10), WorldGen.genRand.Next(2, 7), WorldGen.genRand.Next(2, 7), -2, false, 0.0f, 0.0f, false, true);
                for (int index = 0; index < Main.maxTilesX; ++index)
                {
                    if (!Main.tile[index, Main.maxTilesY - 145].active())
                    {
                        Main.tile[index, Main.maxTilesY - 145].liquid = byte.MaxValue;
                        Main.tile[index, Main.maxTilesY - 145].lava(true);
                    }
                    if (!Main.tile[index, Main.maxTilesY - 144].active())
                    {
                        Main.tile[index, Main.maxTilesY - 144].liquid = byte.MaxValue;
                        Main.tile[index, Main.maxTilesY - 144].lava(true);
                    }
                }
                for (int index = 0; index < (int)(Main.maxTilesX * Main.maxTilesY * 0.0008) / 2; ++index)
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(Main.maxTilesY - 140, Main.maxTilesY), WorldGen.genRand.Next(1, 6), WorldGen.genRand.Next(2, 6), TileType<Quartz>(), false, 0.0f, 0.0f, false, true);
                for (int index = 0; index < (int)(Main.maxTilesX * Main.maxTilesY * 0.0008); ++index)
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(Main.maxTilesY - 140, Main.maxTilesY), WorldGen.genRand.Next(2, 7), WorldGen.genRand.Next(3, 7), TileType<ArqueriteOre>(), false, 0.0f, 0.0f, false, true);
				for (int index = 0; index < (int)(Main.maxTilesX * Main.maxTilesY * 0.0008); ++index)
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(Main.maxTilesY - 140, Main.maxTilesY), WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(5, 9), TileType<Shalestone>(), false, 0.0f, 0.0f, false, true);
                Gems();
                AddDepthHouses();
            }

            void Gems()
            {
                for (int type = 63; type <= 68; ++type)
                {
                    int tile = 0;
                    float num1 = 0.0f;
                    if (type == 67)
                    {
                        num1 = Main.maxTilesX * 0.5f;
                        tile = TileType<ShalestoneAmethyst>();
                    }
                    else if (type == 66)
                    {
                        num1 = Main.maxTilesX * 0.45f;
                        tile = TileType<ShalestoneTopaz>();
                    }
                    else if (type == 63)
                    {
                        num1 = Main.maxTilesX * 0.3f;
                        tile = TileType<ShalestoneSapphire>();
                    }
                    else if (type == 65)
                    {
                        num1 = Main.maxTilesX * 0.25f;
                        tile = TileType<ShalestoneEmerald>();
                    }
                    else if (type == 64)
                    {
                        num1 = Main.maxTilesX * 0.1f;
                        tile = TileType<ShalestoneRuby>();
                    }
                    else if (type == 68)
                    {
                        num1 = Main.maxTilesX * 0.05f;
                        tile = TileType<ShalestoneDiamond>();
                    }
                    float num2 = num1 * 0.2f;
                    for (int index = 0; index < num2; ++index)
                    {
                        int i = WorldGen.genRand.Next(0, Main.maxTilesX);
                        int j;
                        for (j = WorldGen.genRand.Next(Main.maxTilesY - 140, Main.maxTilesY); Main.tile[i, j].type != 1; j = WorldGen.genRand.Next(Main.maxTilesY - 140, Main.maxTilesY))
                            i = WorldGen.genRand.Next(0, Main.maxTilesX);
                        WorldGen.TileRunner(i, j, WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 7), tile, false, 0.0f, 0.0f, false, true);
                    }
                }
                for (int index1 = 0; index1 < 2; ++index1)
                {
                    int num1 = 1;
                    int num2 = 5;
                    int num3 = Main.maxTilesX - 5;
                    if (index1 == 1)
                    {
                        num1 = -1;
                        num2 = Main.maxTilesX - 5;
                        num3 = 5;
                    }
                    int index2 = num2;
                    while (index2 != num3)
                    {
                        for (int index3 = 10; index3 < Main.maxTilesY - 10; ++index3)
                        {
                            if (Main.tile[index2, index3].active() && Main.tile[index2, index3 + 1].active() && Main.tileSand[Main.tile[index2, index3].type] && Main.tileSand[Main.tile[index2, index3 + 1].type])
                            {
                                ushort type = Main.tile[index2, index3].type;
                                int index4 = index2 + num1;
                                int index5 = index3 + 1;
                                if (!Main.tile[index4, index3].active() && !Main.tile[index4, index3 + 1].active())
                                {
                                    while (!Main.tile[index4, index5].active())
                                        ++index5;
                                    int index6 = index5 - 1;
                                    Main.tile[index2, index3].active(false);
                                    Main.tile[index4, index6].active(true);
                                    Main.tile[index4, index6].type = type;
                                }
                            }
                        }
                        index2 += num1;
                    }
                }
            }
        }

        public static void AddDepthHouses()
        {
            int minValue = (int)(Main.maxTilesX * 0.25);
            for (int i = minValue; i < Main.maxTilesX - minValue; ++i)
            {
                int j = Main.maxTilesY - 40;
                while (Main.tile[i, j].active() || Main.tile[i, j].liquid > 0)
                    --j;
                if (Main.tile[i, j + 1].active())
                {
                    ushort tileType = (ushort)WorldGen.genRand.Next(75, 77);
                    byte wallType = (byte)WallType<ArqueriteBrickWallUnsafe>();
                    if (WorldGen.genRand.Next(5) > 0)
                        tileType = 75;
                    if (tileType == 75)
                        wallType = (byte)WallType<QuartzBrickWallUnsafe>();
                    DepthsFort(i, j, tileType, wallType);
                    i += WorldGen.genRand.Next(30, 130);
                    if (WorldGen.genRand.Next(10) == 0)
                        i += WorldGen.genRand.Next(0, 200);
                }
            }
            float num1 = Main.maxTilesX / 4200;
            for (int index1 = 0; index1 < 200.0 * num1; ++index1)
            {
                int num2 = 0;
                bool flag1 = false;
                while (!flag1)
                {
                    ++num2;
                    int index2 = WorldGen.genRand.Next((int)(Main.maxTilesX * 0.2), (int)(Main.maxTilesX * 0.8));
                    int j = WorldGen.genRand.Next(Main.maxTilesY - 300, Main.maxTilesY - 20);
                    if (Main.tile[index2, j].active() && (Main.tile[index2, j].type == TileType<QuartzBricks>() || Main.tile[index2, j].type == TileType<ArqueriteBricks>()))
                    {
                        int num3 = 0;
                        if (Main.tile[index2 - 1, j].wall > 0)
                            num3 = -1;
                        else if (Main.tile[index2 + 1, j].wall > 0)
                            num3 = 1;
                        if (!Main.tile[index2 + num3, j].active() && !Main.tile[index2 + num3, j + 1].active())
                        {
                            bool flag2 = false;
                            for (int index3 = index2 - 8; index3 < index2 + 8; ++index3)
                            {
                                for (int index4 = j - 8; index4 < j + 8; ++index4)
                                {
                                    if (Main.tile[index3, index4].active() && Main.tile[index3, index4].type == TileType<GeoTorch>())
                                    {
                                        flag2 = true;
                                        break;
                                    }
                                }
                            }
                            if (!flag2)
                            {
                                WorldGen.PlaceTile(index2 + num3, j, TileType<GeoTorch>(), true, true, -1);
                                flag1 = true;
                            }
                        }
                    }
                    if (num2 > 1000)
                        flag1 = true;
                }
            }
            float num4 = 4200000f / Main.maxTilesX;
            for (int index1 = 0; index1 < num4; ++index1)
            {
                int i1 = WorldGen.genRand.Next(minValue, Main.maxTilesX - minValue);
                int j;
                for (j = WorldGen.genRand.Next(Main.maxTilesY - 250, Main.maxTilesY - 20); Main.tile[i1, j].wall != WallType<ArqueriteBrickWallUnsafe>() && Main.tile[i1, j].wall != WallType<QuartzBrickWallUnsafe>() || Main.tile[i1, j].active(); j = WorldGen.genRand.Next(Main.maxTilesY - 250, Main.maxTilesY - 20))
                    i1 = WorldGen.genRand.Next(minValue, Main.maxTilesX - minValue);
                if ((Main.tile[i1, j].wall == WallType<ArqueriteBrickWallUnsafe>() || Main.tile[i1, j].wall == WallType<QuartzBrickWallUnsafe>()) && !Main.tile[i1, j].active())
                {
                    while (!WorldGen.SolidTile(i1, j) && j < Main.maxTilesY - 20)
                        ++j;
                    int index2 = j - 1;
                    int i2 = i1;
                    int i3 = i1;
                    while (!Main.tile[i2, index2].active() && WorldGen.SolidTile(i2, index2 + 1))
                        --i2;
                    int num2 = i2 + 1;
                    while (!Main.tile[i3, index2].active() && WorldGen.SolidTile(i3, index2 + 1))
                        ++i3;
                    int num3 = i3 - 1;
                    int num5 = num3 - num2;
                    int index3 = (num3 + num2) / 2;
                    if (!Main.tile[index3, index2].active() && (Main.tile[index3, index2].wall == WallType<ArqueriteBrickWallUnsafe>() || Main.tile[index3, index2].wall == WallType<QuartzBrickWallUnsafe>()) && WorldGen.SolidTile(index3, index2 + 1))
                    {
                        int style1 = 16;
                        int style2 = 13;
                        int style3 = 14;
                        int style4 = 49;
                        int style5 = 4;
                        int style6 = 8;
                        int style7 = 15;
                        int style8 = 9;
                        int style9 = 10;
                        int style10 = 17;
                        int style11 = 25;
                        int style12 = 25;
                        int style13 = 23;
                        int style14 = 25;
                        int num6 = WorldGen.genRand.Next(13);
                        int num7 = 0;
                        int num8 = 0;
                        if (num6 == 0)
                        {
                            num7 = 5;
                            num8 = 4;
                        }
                        if (num6 == 1)
                        {
                            num7 = 4;
                            num8 = 3;
                        }
                        if (num6 == 2)
                        {
                            num7 = 3;
                            num8 = 5;
                        }
                        if (num6 == 3)
                        {
                            num7 = 4;
                            num8 = 6;
                        }
                        if (num6 == 4)
                        {
                            num7 = 3;
                            num8 = 3;
                        }
                        if (num6 == 5)
                        {
                            num7 = 5;
                            num8 = 3;
                        }
                        if (num6 == 6)
                        {
                            num7 = 5;
                            num8 = 4;
                        }
                        if (num6 == 7)
                        {
                            num7 = 5;
                            num8 = 4;
                        }
                        if (num6 == 8)
                        {
                            num7 = 5;
                            num8 = 4;
                        }
                        if (num6 == 9)
                        {
                            num7 = 3;
                            num8 = 5;
                        }
                        if (num6 == 10)
                        {
                            num7 = 5;
                            num8 = 3;
                        }
                        if (num6 == 11)
                        {
                            num7 = 2;
                            num8 = 4;
                        }
                        if (num6 == 12)
                        {
                            num7 = 3;
                            num8 = 3;
                        }
                        for (int index4 = index3 - num7; index4 <= index3 + num7; ++index4)
                        {
                            for (int index5 = index2 - num8; index5 <= index2; ++index5)
                            {
                                if (Main.tile[index4, index5].active())
                                {
                                    num6 = -1;
                                    break;
                                }
                            }
                        }
                        if (num5 < num7 * 1.75)
                            num6 = -1;
                        if (num6 == 0)
                        {
                            WorldGen.PlaceTile(index3, index2, 14, true, false, -1, style2);
                            int num9 = WorldGen.genRand.Next(6);
                            if (num9 < 3)
                                WorldGen.PlaceTile(index3 + num9, index2 - 2, 33, true, false, -1, style12);
                            if (Main.tile[index3, index2].active())
                            {
                                if (!Main.tile[index3 - 2, index2].active())
                                {
                                    WorldGen.PlaceTile(index3 - 2, index2, TileType<QuartzChair>(), true, false, -1);
                                    if (Main.tile[index3 - 2, index2].active())
                                    {
                                        Main.tile[index3 - 2, index2].frameX += 18;
                                        Main.tile[index3 - 2, index2 - 1].frameX += 18;
                                    }
                                }
                                if (!Main.tile[index3 + 2, index2].active())
                                    WorldGen.PlaceTile(index3 + 2, index2, TileType<QuartzChair>(), true, false, -1);
                            }
                        }
                        else if (num6 == 1)
                        {
                            WorldGen.PlaceTile(index3, index2, 18, true, false, -1, style3);
                            int num9 = WorldGen.genRand.Next(4);
                            if (num9 < 2)
                                WorldGen.PlaceTile(index3 + num9, index2 - 1, 33, true, false, -1, style12);
                            if (Main.tile[index3, index2].active())
                            {
                                if (WorldGen.genRand.Next(2) == 0)
                                {
                                    if (!Main.tile[index3 - 1, index2].active())
                                    {
                                        WorldGen.PlaceTile(index3 - 1, index2, TileType<QuartzChair>(), true, false, -1);
                                        if (Main.tile[index3 - 1, index2].active())
                                        {
                                            Main.tile[index3 - 1, index2].frameX += 18;
                                            Main.tile[index3 - 1, index2 - 1].frameX += 18;
                                        }
                                    }
                                }
                                else if (!Main.tile[index3 + 2, index2].active())
                                    WorldGen.PlaceTile(index3 + 2, index2, TileType<QuartzChair>(), true, false, -1);
                            }
                        }
                        else if (num6 == 2)
                            WorldGen.PlaceTile(index3, index2, 105, true, false, -1, style4);
                        else if (num6 == 3)
                            WorldGen.PlaceTile(index3, index2, 101, true, false, -1, style5);
                        else if (num6 == 4)
                        {
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                WorldGen.PlaceTile(index3, index2, TileType<QuartzChair>(), true, false, -1);
                                Main.tile[index3, index2].frameX += 18;
                                Main.tile[index3, index2 - 1].frameX += 18;
                            }
                            else
                                WorldGen.PlaceTile(index3, index2, TileType<QuartzChair>(), true, false, -1);
                        }
                        else if (num6 == 5)
                        {
                            if (WorldGen.genRand.Next(2) == 0)
                                WorldGen.Place4x2(index3, index2, 79, 1, style6);
                            else
                                WorldGen.Place4x2(index3, index2, 79, -1, style6);
                        }
                        else if (num6 == 6)
                            WorldGen.PlaceTile(index3, index2, 87, true, false, -1, style7);
                        else if (num6 == 7)
                            WorldGen.PlaceTile(index3, index2, 88, true, false, -1, style8);
                        else if (num6 == 8)
                            WorldGen.PlaceTile(index3, index2, 89, true, false, -1, style9);
                        else if (num6 == 9)
                            WorldGen.PlaceTile(index3, index2, 104, true, false, -1, style10);
                        else if (num6 == 10)
                        {
                            if (WorldGen.genRand.Next(2) == 0)
                                WorldGen.Place4x2(index3, index2, 90, 1, style14);
                            else
                                WorldGen.Place4x2(index3, index2, 90, -1, style14);
                        }
                        else if (num6 == 11)
                            WorldGen.PlaceTile(index3, index2, 93, true, false, -1, style13);
                        else if (num6 == 12)
                            WorldGen.PlaceTile(index3, index2, 100, true, false, -1, style11);
                    }
                }
            }
            float num10 = 420000f / Main.maxTilesX;
            for (int index1 = 0; index1 < num10; ++index1)
            {
                int index2 = WorldGen.genRand.Next(minValue, Main.maxTilesX - minValue);
                int index3;
                for (index3 = WorldGen.genRand.Next(Main.maxTilesY - 250, Main.maxTilesY - 20); Main.tile[index2, index3].wall != WallType<ArqueriteBrickWallUnsafe>() && Main.tile[index2, index3].wall != WallType<QuartzBrickWallUnsafe>() || Main.tile[index2, index3].active(); index3 = WorldGen.genRand.Next(Main.maxTilesY - 250, Main.maxTilesY - 20))
                    index2 = WorldGen.genRand.Next(minValue, Main.maxTilesX - minValue);
                for (int index4 = 0; index4 < 2; ++index4)
                {
                    int index5 = index2;
                    int index6 = index2;
                    while (!Main.tile[index5, index3].active() && (Main.tile[index5, index3].wall == WallType<ArqueriteBrickWallUnsafe>() || Main.tile[index5, index3].wall == WallType<QuartzBrickWallUnsafe>()))
                        --index5;
                    int num2 = index5 + 1;
                    while (!Main.tile[index6, index3].active() && (Main.tile[index6, index3].wall == WallType<ArqueriteBrickWallUnsafe>() || Main.tile[index6, index3].wall == WallType<QuartzBrickWallUnsafe>()))
                        ++index6;
                    int num3 = index6 - 1;
                    index2 = (num2 + num3) / 2;
                    int index7 = index3;
                    int index8 = index3;
                    while (!Main.tile[index2, index7].active() && (Main.tile[index2, index7].wall == WallType<ArqueriteBrickWallUnsafe>() || Main.tile[index2, index7].wall == WallType<QuartzBrickWallUnsafe>()))
                        --index7;
                    int num5 = index7 + 1;
                    while (!Main.tile[index2, index8].active() && (Main.tile[index2, index8].wall == WallType<ArqueriteBrickWallUnsafe>() || Main.tile[index2, index8].wall == WallType<QuartzBrickWallUnsafe>()))
                        ++index8;
                    int num6 = index8 - 1;
                    index3 = (num5 + num6) / 2;
                }
                int index9 = index2;
                int index10 = index2;
                while (!Main.tile[index9, index3].active() && !Main.tile[index9, index3 - 1].active() && !Main.tile[index9, index3 + 1].active())
                    --index9;
                int num7 = index9 + 1;
                while (!Main.tile[index10, index3].active() && !Main.tile[index10, index3 - 1].active() && !Main.tile[index10, index3 + 1].active())
                    ++index10;
                int num8 = index10 - 1;
                int index11 = index3;
                int index12 = index3;
                while (!Main.tile[index2, index11].active() && !Main.tile[index2 - 1, index11].active() && !Main.tile[index2 + 1, index11].active())
                    --index11;
                int num9 = index11 + 1;
                while (!Main.tile[index2, index12].active() && !Main.tile[index2 - 1, index12].active() && !Main.tile[index2 + 1, index12].active())
                    ++index12;
                int num11 = index12 - 1;
                int num12 = (num7 + num8) / 2;
                int num13 = (num9 + num11) / 2;
                int num14 = num8 - num7;
                int num15 = num11 - num9;
                int num16 = 7;
                if (num14 > num16 && num15 > 5)
                {
                    int num2 = 0;
                    if (WorldGen.nearPicture2(num12, num13))
                        num2 = -1;
                    if (num2 == 0)
                    {
                        Vector2 vector2 = WorldGen.randHellPicture();
                        int x = (int)vector2.X;
                        int y = (int)vector2.Y;
                        if (!WorldGen.nearPicture(num12, num13))
                            WorldGen.PlaceTile(num12, num13, x, true, false, -1, y);
                    }
                }
            }
            int[] numArray = new int[3] { WorldGen.genRand.Next(16, 22), WorldGen.genRand.Next(16, 22), WorldGen.genRand.Next(16, 22) };
            while (numArray[1] == numArray[0])
                numArray[1] = WorldGen.genRand.Next(16, 22);
            while (numArray[2] == numArray[0] || numArray[2] == numArray[1])
                numArray[2] = WorldGen.genRand.Next(16, 22);
            float num17 = 420000f / Main.maxTilesX;
            for (int index1 = 0; index1 < num17; ++index1)
            {
                int i;
                int j1;
                do
                {
                    i = WorldGen.genRand.Next(minValue, Main.maxTilesX - minValue);
                    j1 = WorldGen.genRand.Next(Main.maxTilesY - 250, Main.maxTilesY - 20);
                }
                while (Main.tile[i, j1].wall != WallType<ArqueriteBrickWallUnsafe>() && Main.tile[i, j1].wall != WallType<QuartzBrickWallUnsafe>() || Main.tile[i, j1].active());
                while (!WorldGen.SolidTile(i, j1) && j1 > 10)
                    --j1;
                int j2 = j1 + 1;
                if (Main.tile[i, j2].wall == WallType<ArqueriteBrickWallUnsafe>() || Main.tile[i, j2].wall == WallType<QuartzBrickWallUnsafe>())
                {
                    int num2 = WorldGen.genRand.Next(3);
                    int style1 = 32;
                    int style2 = 32;
                    int num3;
                    int num5;
                    switch (num2)
                    {
                        case 1:
                            num3 = 3;
                            num5 = 3;
                            break;
                        case 2:
                            num3 = 1;
                            num5 = 2;
                            break;
                        default:
                            num3 = 1;
                            num5 = 3;
                            break;
                    }
                    for (int index2 = i - 1; index2 <= i + num3; ++index2)
                    {
                        for (int index3 = j2; index3 <= j2 + num5; ++index3)
                        {
                            Tile tile = Main.tile[i, j2];
                            if (index2 < i || index2 == i + num3)
                            {
                                if (tile.active())
                                {
                                    ushort type = tile.type;
                                    if (type <= 34U)
                                    {
                                        if (type - 10U > 1U && type != 34)
                                            continue;
                                    }
                                    else if (type != 42 && type != 91)
                                        continue;
                                    num2 = -1;
                                }
                            }
                            else if (tile.active())
                                num2 = -1;
                        }
                    }
                    switch (num2)
                    {
                        case 0:
                            WorldGen.PlaceTile(i, j2, 91, true, false, -1, numArray[WorldGen.genRand.Next(3)]);
                            continue;
                        case 1:
                            WorldGen.PlaceTile(i, j2, 34, true, false, -1, style1);
                            continue;
                        case 2:
                            WorldGen.PlaceTile(i, j2, 42, true, false, -1, style2);
                            continue;
                        default:
                            continue;
                    }
                }
            }
        }

        public static void DepthsFort(int i, int j, ushort tileType = 75, byte wallType = 14)
        {
            int[] numArray1 = new int[5];
            int[] numArray2 = new int[5];
            int[] numArray3 = new int[10];
            int[] numArray4 = new int[10];
            int minValue1 = 8;
            int maxValue1 = 20;
            numArray1[2] = i - WorldGen.genRand.Next(minValue1 / 2, maxValue1 / 2);
            numArray2[2] = i + WorldGen.genRand.Next(minValue1 / 2, maxValue1 / 2);
            numArray1[3] = numArray2[2];
            numArray2[3] = numArray1[3] + WorldGen.genRand.Next(minValue1, maxValue1);
            numArray1[4] = numArray2[3];
            numArray2[4] = numArray1[4] + WorldGen.genRand.Next(minValue1, maxValue1);
            numArray2[1] = numArray1[2];
            numArray1[1] = numArray2[1] - WorldGen.genRand.Next(minValue1, maxValue1);
            numArray2[0] = numArray1[1];
            numArray1[0] = numArray2[0] - WorldGen.genRand.Next(minValue1, maxValue1);
            int minValue2 = 6;
            int maxValue2 = 12;
            numArray3[3] = j - WorldGen.genRand.Next(minValue2, maxValue2);
            numArray4[3] = j;
            for (int index = 4; index < 10; ++index)
            {
                numArray3[index] = numArray4[index - 1];
                numArray4[index] = numArray3[index] + WorldGen.genRand.Next(minValue2, maxValue2);
            }
            for (int index = 2; index >= 0; --index)
            {
                numArray4[index] = numArray3[index + 1];
                numArray3[index] = numArray4[index] - WorldGen.genRand.Next(minValue2, maxValue2);
            }
            bool flag1 = false;
            bool flag2 = false;
            bool[,] flagArray1 = new bool[5, 10];
            int num1 = 3;
            int num2 = 3;
            for (int index1 = 0; index1 < 2; ++index1)
            {
                if (WorldGen.genRand.Next(3) == 0)
                {
                    flag1 = true;
                    int index2 = WorldGen.genRand.Next(10);
                    if (index2 < num1)
                        num1 = index2;
                    if (index2 > num2)
                        num2 = index2;
                    int index3 = 1;
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                        flagArray1[0, index2] = true;
                        flagArray1[1, index2] = true;
                        index3 = 0;
                    }
                    else
                        flagArray1[1, index2] = true;
                    int num3 = WorldGen.genRand.Next(2);
                    if (num3 == 0)
                        num3 = -1;
                    int num4 = WorldGen.genRand.Next(10);
                    while (num4 > 0 && index2 >= 0 && index2 < 10)
                    {
                        flagArray1[index3, index2] = true;
                        index2 += num3;
                    }
                }
                if (WorldGen.genRand.Next(3) == 0)
                {
                    flag2 = true;
                    int index2 = WorldGen.genRand.Next(10);
                    if (index2 < num1)
                        num1 = index2;
                    if (index2 > num2)
                        num2 = index2;
                    int index3 = 3;
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                        flagArray1[3, index2] = true;
                        flagArray1[4, index2] = true;
                        index3 = 4;
                    }
                    else
                        flagArray1[3, index2] = true;
                    int num3 = WorldGen.genRand.Next(2);
                    if (num3 == 0)
                        num3 = -1;
                    int num4 = WorldGen.genRand.Next(10);
                    while (num4 > 0 && index2 >= 0 && index2 < 10)
                    {
                        flagArray1[index3, index2] = true;
                        index2 += num3;
                    }
                }
            }
            for (int index1 = 0; index1 < 5; ++index1)
            {
                int index2 = numArray1[index1];
                bool flag3 = false;
                for (int index3 = Main.maxTilesY - 200; index3 < Main.maxTilesY; ++index3)
                {
                    if (Main.tile[index2, index3].wall > 0)
                        flag3 = true;
                }
                if (flag3)
                {
                    for (int index3 = 0; index3 < 10; ++index3)
                        flagArray1[index1, index3] = false;
                }
            }
            int num5 = WorldGen.genRand.Next(10);
            if (num5 < num1)
                num1 = num5;
            int num6 = WorldGen.genRand.Next(10);
            if (num6 > num2)
                num2 = num6;
            if (!flag1 && !flag2)
            {
                while (num2 - num1 < 5)
                {
                    int num3 = WorldGen.genRand.Next(10);
                    if (num3 < num1)
                        num1 = num3;
                    int num4 = WorldGen.genRand.Next(10);
                    if (num4 > num2)
                        num2 = num4;
                }
            }
            for (int index = num1; index <= num2; ++index)
                flagArray1[2, index] = true;
            for (int index1 = 0; index1 < 5; ++index1)
            {
                for (int index2 = 0; index2 < 10; ++index2)
                {
                    if (flagArray1[index1, index2] && (numArray3[index2] < Main.maxTilesY - 200 || numArray4[index2] > Main.maxTilesY - 20))
                        flagArray1[index1, index2] = false;
                }
            }
            for (int index1 = 0; index1 < 5; ++index1)
            {
                for (int index2 = 0; index2 < 10; ++index2)
                {
                    if (flagArray1[index1, index2])
                    {
                        for (int index3 = numArray1[index1]; index3 <= numArray2[index1]; ++index3)
                        {
                            for (int index4 = numArray3[index2]; index4 <= numArray4[index2]; ++index4)
                            {
                                Main.tile[index3, index4].liquid = 0;
                                if (index3 == numArray1[index1] || index3 == numArray2[index1] || (index4 == numArray3[index2] || index4 == numArray4[index2]))
                                {
                                    Main.tile[index3, index4].active(true);
                                    if (tileType != 77)
                                    {
                                        if (tileType == 76)
                                            Main.tile[index3, index4].type = (ushort)TileType<ArqueriteBricks>();
                                        else
                                            if (tileType == 75)
                                                Main.tile[index3, index4].type = (ushort)TileType<QuartzBricks>();
                                            else
                                                Main.tile[index3, index4].type = tileType;
                                    }
                                    else
                                        Main.tile[index3, index4].type = (ushort)TileType<Gemforge>();
                                    Main.tile[index3, index4].halfBrick(false);
                                    Main.tile[index3, index4].slope(0);
                                }
                                else
                                {
                                    Main.tile[index3, index4].wall = wallType;
                                    Main.tile[index3, index4].active(false);
                                }
                            }
                        }
                    }
                }
            }
            int style1 = 19;
            int style2 = 13;
            for (int index1 = 0; index1 < 4; ++index1)
            {
                bool[] flagArray2 = new bool[10];
                bool flag3 = false;
                for (int index2 = 0; index2 < 10; ++index2)
                {
                    if (flagArray1[index1, index2] && flagArray1[index1 + 1, index2])
                    {
                        flagArray2[index2] = true;
                        flag3 = true;
                    }
                }
                while (flag3)
                {
                    int index2 = WorldGen.genRand.Next(10);
                    if (flagArray2[index2])
                    {
                        flag3 = false;
                        Main.tile[numArray2[index1], numArray4[index2] - 1].active(false);
                        Main.tile[numArray2[index1], numArray4[index2] - 2].active(false);
                        Main.tile[numArray2[index1], numArray4[index2] - 3].active(false);
                        Main.tile[numArray2[index1], numArray4[index2] - 1].wall = wallType;
                        Main.tile[numArray2[index1], numArray4[index2] - 2].wall = wallType;
                        Main.tile[numArray2[index1], numArray4[index2] - 3].wall = wallType;
                        WorldGen.PlaceTile(numArray2[index1], numArray4[index2] - 1, TileType<QuartzDoorClosed>(), true, false, -1);
                    }
                }
            }
            for (int index1 = 0; index1 < 5; ++index1)
            {
                for (int index2 = 0; index2 < 10; ++index2)
                {
                    if (flagArray1[index1, index2])
                    {
                        if (index2 > 0 && flagArray1[index1, index2 - 1])
                        {
                            int num3 = WorldGen.genRand.Next(numArray1[index1] + 2, numArray2[index1] - 1);
                            int num4;
                            for (num4 = WorldGen.genRand.Next(numArray1[index1] + 2, numArray2[index1] - 1); num4 - num3 < 2 || num4 - num3 > 5; num4 = WorldGen.genRand.Next(numArray1[index1] + 2, numArray2[index1] - 1))
                                num3 = WorldGen.genRand.Next(numArray1[index1] + 2, numArray2[index1] - 1);
                            for (int i1 = num3; i1 <= num4; ++i1)
                            {
                                Main.tile[i1, numArray3[index2]].active(false);
                                WorldGen.PlaceTile(i1, numArray3[index2], TileType<QuartzPlatform>(), true, true, -1);
                                Main.tile[i1, numArray3[index2]].wall = wallType;
                            }
                        }
                        if (index1 < 4 && flagArray1[index1 + 1, index2] && WorldGen.genRand.Next(3) == 0)
                        {
                            Main.tile[numArray2[index1], numArray4[index2] - 1].active(false);
                            Main.tile[numArray2[index1], numArray4[index2] - 2].active(false);
                            Main.tile[numArray2[index1], numArray4[index2] - 3].active(false);
                            Main.tile[numArray2[index1], numArray4[index2] - 1].wall = wallType;
                            Main.tile[numArray2[index1], numArray4[index2] - 2].wall = wallType;
                            Main.tile[numArray2[index1], numArray4[index2] - 3].wall = wallType;
                            WorldGen.PlaceTile(numArray2[index1], numArray4[index2] - 1, TileType<QuartzDoorClosed>(), true, false, -1);
                        }
                    }
                }
            }
            bool flag4 = false;
            for (int index1 = 0; index1 < 5; ++index1)
            {
                bool[] flagArray2 = new bool[10];
                for (int index2 = 0; index2 < 10; ++index2)
                {
                    if (flagArray1[index1, index2])
                    {
                        flag4 = true;
                        flagArray2[index2] = true;
                    }
                }
                if (flag4)
                {
                    bool flag3 = false;
                    for (int index2 = 0; index2 < 10; ++index2)
                    {
                        if (flagArray2[index2])
                        {
                            if (!Main.tile[numArray1[index1] - 1, numArray4[index2] - 1].active() && !Main.tile[numArray1[index1] - 1, numArray4[index2] - 2].active() && (!Main.tile[numArray1[index1] - 1, numArray4[index2] - 3].active() && Main.tile[numArray1[index1] - 1, numArray4[index2] - 1].liquid == 0) && Main.tile[numArray1[index1] - 1, numArray4[index2] - 2].liquid == 0 && Main.tile[numArray1[index1] - 1, numArray4[index2] - 3].liquid == 0)
                                flag3 = true;
                            else
                                flagArray2[index2] = false;
                        }
                    }
                    while (flag3)
                    {
                        int index2 = WorldGen.genRand.Next(10);
                        if (flagArray2[index2])
                        {
                            flag3 = false;
                            Main.tile[numArray1[index1], numArray4[index2] - 1].active(false);
                            Main.tile[numArray1[index1], numArray4[index2] - 2].active(false);
                            Main.tile[numArray1[index1], numArray4[index2] - 3].active(false);
                            WorldGen.PlaceTile(numArray1[index1], numArray4[index2] - 1, TileType<QuartzDoorClosed>(), true, false, -1);
                        }
                    }
                    break;
                }
            }
            bool flag5 = false;
            for (int index1 = 4; index1 >= 0; --index1)
            {
                bool[] flagArray2 = new bool[10];
                for (int index2 = 0; index2 < 10; ++index2)
                {
                    if (flagArray1[index1, index2])
                    {
                        flag5 = true;
                        flagArray2[index2] = true;
                    }
                }
                if (flag5)
                {
                    bool flag3 = false;
                    for (int index2 = 0; index2 < 10; ++index2)
                    {
                        if (flagArray2[index2])
                        {
                            if (!Main.tile[numArray2[index1] + 1, numArray4[index2] - 1].active() && !Main.tile[numArray2[index1] + 1, numArray4[index2] - 2].active() && (!Main.tile[numArray2[index1] + 1, numArray4[index2] - 3].active() && (int)Main.tile[numArray2[index1] + 1, numArray4[index2] - 1].liquid == 0) && ((int)Main.tile[numArray2[index1] + 1, numArray4[index2] - 2].liquid == 0 && (int)Main.tile[numArray2[index1] + 1, numArray4[index2] - 3].liquid == 0))
                                flag3 = true;
                            else
                                flagArray2[index2] = false;
                        }
                    }
                    while (flag3)
                    {
                        int index2 = WorldGen.genRand.Next(10);
                        if (flagArray2[index2])
                        {
                            flag3 = false;
                            Main.tile[numArray2[index1], numArray4[index2] - 1].active(false);
                            Main.tile[numArray2[index1], numArray4[index2] - 2].active(false);
                            Main.tile[numArray2[index1], numArray4[index2] - 3].active(false);
                            WorldGen.PlaceTile(numArray2[index1], numArray4[index2] - 1, TileType<QuartzDoorClosed>(), true, false, -1);
                        }
                    }
                    break;
                }
            }
            bool flag6 = false;
            for (int index1 = 0; index1 < 10; ++index1)
            {
                bool[] flagArray2 = new bool[10];
                for (int index2 = 0; index2 < 5; ++index2)
                {
                    if (flagArray1[index2, index1])
                    {
                        flag6 = true;
                        flagArray2[index2] = true;
                    }
                }
                if (flag6)
                {
                    bool flag3 = true;
                    while (flag3)
                    {
                        int index2 = WorldGen.genRand.Next(5);
                        if (flagArray2[index2])
                        {
                            int num3 = WorldGen.genRand.Next(numArray1[index2] + 2, numArray2[index2] - 1);
                            int num4;
                            for (num4 = WorldGen.genRand.Next(numArray1[index2] + 2, numArray2[index2] - 1); num4 - num3 < 2 || num4 - num3 > 5; num4 = WorldGen.genRand.Next(numArray1[index2] + 2, numArray2[index2] - 1))
                                num3 = WorldGen.genRand.Next(numArray1[index2] + 2, numArray2[index2] - 1);
                            for (int index3 = num3; index3 <= num4; ++index3)
                            {
                                if (Main.tile[index3, numArray3[index1] - 1].active() || Main.tile[index3, numArray3[index1] - 1].liquid > 0)
                                    flag3 = false;
                            }
                            if (flag3)
                            {
                                for (int i1 = num3; i1 <= num4; ++i1)
                                {
                                    Main.tile[i1, numArray3[index1]].active(false);
                                    WorldGen.PlaceTile(i1, numArray3[index1], TileType<QuartzPlatform>(), true, true, -1);
                                }
                            }
                            flag3 = false;
                        }
                    }
                    break;
                }
            }
        }

        public override TagCompound Save()
        {
            var toSave = new TagCompound
            {
                { "TheDepths:depthsorHell", depthsorHell },
            };
            return toSave;
        }

        public override void Load(TagCompound tag)
        {
            if (tag.ContainsKey("TheDepths:depthsorHell"))
            {
                depthsorHell = tag.Get<bool>("TheDepths:depthsorHell");
            }
        }
		
		public static void TreeGen(GenerationProgress progress)
        {
            progress.Message = "Growing gemtrees";
            progress.Set(0.0f);
            for (int hbx = 50; hbx < Main.maxTilesX - 50; hbx++)
            {
                for (int hby = Main.maxTilesY - 200; hby < Main.maxTilesY - 50; hby++)
                {
                    if (Main.tile[hbx, hby].active() && !Main.tile[hbx, hby - 1].active() ||
                        Main.tile[hbx, hby].active() && !Main.tile[hbx, hby + 1].active() ||
                        Main.tile[hbx, hby].active() && !Main.tile[hbx - 1, hby].active() ||
                        Main.tile[hbx, hby].active() && !Main.tile[hbx + 1, hby].active())
                    {
                        if (Main.tile[hbx, hby].type == (ushort)TileType<ShaleBlock>())
                        {
                            if (WorldGen.genRand.Next(1) == 0)
                            {
                                WorldGen.GrowTree(hbx, hby - 1);
                            }
                        }
                    }
                }
            }
            progress.Set(1f);
        }
    }
}

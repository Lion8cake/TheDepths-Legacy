using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheDepths.Items;
using TheDepths.Items.Placeable;

namespace TheDepths.NPCs
{
    public class NpcDrops : GlobalNPC
    {
        public override void NPCLoot(NPC npc) //I like all the drops lined up and organised. This has all npc drop loot apart from the Meowzer and prickster as they were made by other people
        {

            if (npc.type == mod.NPCType("Geomancer"))
            {
                if (Main.rand.Next(85) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Geode"), Main.rand.Next(1, 1));
                }

                if (Main.rand.Next(5000) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PurplePlumbersHat"), 1);
                }

                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowSphere"), 1);
                }

                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LivingShadowStaff"), 1);
                }

                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StoneRose"), 1);
                }
            }
            if (npc.type == mod.NPCType("Shade"))
            {
                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RebyRelic"), 1);
                }
                if (Main.rand.Next(500) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CheeseAndCrackers"), 1);
                }
            }

            if (npc.type == mod.NPCType("SapphireSerpent"))
            {
                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SapphireShovel"), 1);
                }

                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Sapphire, 1);
                }

                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AquaStone"), 1);
                }
            }
            if (npc.type == mod.NPCType("GoldBat"))
            {
                if (Main.rand.Next(10) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Topaz, 1);
                }
            }
            if (npc.type == mod.NPCType("Ferroslime"))
            {
                if (Main.rand.Next(33) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LodeStone"), 1);
                }
                if (Main.rand.Next(0) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel, Main.rand.Next(5, 15));
                }
            }
            if (npc.type == mod.NPCType("ShadowBat"))
            {
                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Emerald, 1);
                }
            }
            if (npc.type == mod.NPCType("CrystalKing"))
            {
                if (Main.rand.Next(0) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DiamondDust"), Main.rand.Next(1, 3));
                }

                if (Main.rand.Next(100) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CrystalCrown"), 1);
                }

                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Diamond, 1);
                }
            }
            if (npc.type == mod.NPCType("KingCoal"))
            {
                if (Main.rand.Next(0) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Ember"), Main.rand.Next(1, 3));
                }

                if (Main.rand.Next(100) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CharredCrown"), 1);
                }

                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Ruby, 1);
                }
            }
        }

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if (TheDepthsWorldGen.depthsorHell)
            {
                pool.Remove(NPCID.Hellbat);
                pool.Remove(NPCID.LavaSlime);
                pool.Remove(NPCID.FireImp);
                pool.Remove(NPCID.Demon);
                pool.Remove(NPCID.VoodooDemon);
                pool.Remove(NPCID.BoneSerpentHead);
                pool.Remove(NPCID.BoneSerpentBody);
                pool.Remove(NPCID.BoneSerpentTail);
                pool.Remove(NPCID.DemonTaxCollector);
                pool.Remove(NPCID.Lavabat);
                pool.Remove(NPCID.RedDevil);
            }
        }
    }
}

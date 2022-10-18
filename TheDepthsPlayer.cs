using TheDepths.Buffs;
using TheDepths.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using System.IO;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using System.Collections.Generic;
using TheDepths.Items;
using TheDepths.Projectiles.Nohitweapon;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace TheDepths
{
    public class TheDepthsPlayer : ModPlayer
    {
        public BitsByte largeGems;
        public BitsByte ownedLargeGems;
        public BitsByte hasLargeGems;
        public bool merPoison;
        public bool slowWater;
        public bool merBoiling;
        public bool merImbue;
        public bool aStone;
        public bool lodeStone;
        public bool noHit;

        public bool geodeCrystal;
        public bool livingShadow;
        public bool ShadePet;
		
		public bool ZoneDepths;

        public override void PreUpdate()
        {
            Point tileCoordinates1 = player.Center.ToTileCoordinates();
           	if (tileCoordinates1.Y > Main.maxTilesY - 320 && Main.UseHeatDistortion && TheDepthsWorldGen.depthsorHell)
            {
                Filters.Scene["HeatDistortion"].Deactivate();
                if (Filters.Scene["HeatDistortion"].Active)
          	    {
           	        Filters.Scene["HeatDistortion"].Deactivate();
		        }
       	    }
        }

        public override void ResetEffects()
        {
            largeGems = 0;
            merPoison = false;
            slowWater = false;
            merBoiling = false;
            merImbue = false;
            aStone = false;
            lodeStone = false;

            geodeCrystal = false;
            livingShadow = false;
            ShadePet = false;


            for (int i = 0; i < Main.maxNPCs; i++)
            {
                if (Main.npc[i].active && Main.npc[i].boss)
                {
                    return;
                }
            }
            noHit = false;
        }
		
		public override void UpdateBiomes()
		{
	        ZoneDepths = player.ZoneUnderworldHeight && TheDepthsWorldGen.depthsorHell;
		}

		public override bool CustomBiomesMatch(Player other) {
			TheDepthsPlayer modOther = other.GetModPlayer<TheDepthsPlayer>();
			return ZoneDepths == modOther.ZoneDepths;
		}

		public override void CopyCustomBiomesTo(Player other) {
			TheDepthsPlayer modOther = other.GetModPlayer<TheDepthsPlayer>();
			modOther.ZoneDepths = ZoneDepths;
		}

		public override void SendCustomBiomes(BinaryWriter writer) {
			BitsByte flags = new BitsByte();
			flags[0] = ZoneDepths;
			writer.Write(flags);
		}

		public override void ReceiveCustomBiomes(BinaryReader reader) {
			BitsByte flags = reader.ReadByte();
			ZoneDepths = flags[0];
		}

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (merPoison)
            {
                if (Main.rand.NextBool(4) && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, ModContent.DustType<MercuryFire>(), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
            }
            if (slowWater)
            {
                if (Main.rand.NextBool(4) && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, ModContent.DustType<SlowingWaterFire>(), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
            }
            if (merBoiling)
            {
                if (Main.rand.NextBool(4) && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, ModContent.DustType<MercuryFire>(), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0.1f;
                g *= 0.2f;
                b *= 0.7f;
                fullBright = true;
            }
        }

        public override void MeleeEffects(Item item, Rectangle hitbox)
        {
            if (merImbue && Main.rand.NextBool(3))
            {
                Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<MercuryFire>(), player.velocity.X * 0.2f + (float)player.direction * 3f, player.velocity.Y * 0.2f, 100, default(Color), 0.75f);
            }
            if (aStone && Main.rand.NextBool(3))
            {
                Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<SlowingWaterFire>(), player.velocity.X * 0.2f + (float)player.direction * 3f, player.velocity.Y * 0.2f, 100, default(Color), 0.75f);
            }
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (item.melee)
            {
                if (merImbue)
                {
                    target.AddBuff(ModContent.BuffType<MercuryBoiling>(), 360 * Main.rand.Next(1, 1));
                }
                if (aStone)
                {
                    target.AddBuff(ModContent.BuffType<FreezingWater>(), 360 * Main.rand.Next(1, 1));
                }
            }
        }

        public override void OnHitPvp(Item item, Player target, int damage, bool crit)
        {
            if (item.melee)
            {
                if (merImbue)
                {
                    target.AddBuff(ModContent.BuffType<MercuryBoiling>(), 360 * Main.rand.Next(1, 1));
                }
                if (aStone)
                {
                    target.AddBuff(ModContent.BuffType<FreezingWater>(), 360 * Main.rand.Next(1, 1));
                }
            }
        }

        public override void PostUpdate()
        {
            if (lodeStone) Player.defaultItemGrabRange = 107;
        }

        public override void PostUpdateEquips()
        {
            for (int index = 0; index < 59; ++index)
            {
                if (player.inventory[index].type == ModContent.ItemType<LargeOnyx>())
                {
                    largeGems[0] = true;
                }
            }
            if (player.gemCount == 0)
            {
                if (largeGems > 0)
                {
                    ownedLargeGems = (byte)player.ownedLargeGems;
                    hasLargeGems = (byte)largeGems;
                    player.ownedLargeGems = 0;
                    player.gem = -1;
                }
                else
                {
                    ownedLargeGems = 0;
                    hasLargeGems = 0;
                }
            }
        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (Main.myPlayer == player.whoAmI && player.difficulty == 0)
            {
                List<int> intList = new List<int>()
                {
                    ModContent.ItemType<LargeOnyx>(),
                };
                for (int index = 0; index < 59; ++index)
                {
                    if (player.inventory[index].stack > 0 && intList.Contains(player.inventory[index].type))
                    {
                        int number = Item.NewItem(player.getRect(), player.inventory[index].type, 1, false, 0, false, false);
                        Main.item[number].Prefix(player.inventory[index].prefix);
                        Main.item[number].stack = player.inventory[index].stack;
                        Main.item[number].velocity.Y = (float)(Main.rand.Next(-20, 1) * 0.200000002980232);
                        Main.item[number].velocity.X = (float)(Main.rand.Next(-20, 21) * 0.200000002980232);
                        Main.item[number].noGrabDelay = 100;
                        Main.item[number].favorited = false;
                        Main.item[number].newAndShiny = false;
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                            NetMessage.SendData(MessageID.SyncItem, number: number);
                        player.inventory[index].SetDefaults(0, false);
                    }
                }
            }
        }

        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            int num3 = layers.IndexOf(PlayerLayer.MiscEffectsFront);
            if (num3 != -1)
                layers.Insert(num3 + 1, CirclingLargeGems);
            CirclingLargeGems.visible = true;
        }

        public static readonly PlayerLayer CirclingLargeGems = new PlayerLayer("TheDepths", nameof(CirclingLargeGems), PlayerLayer.MiscEffectsFront, drawInfo =>
        {
            if (drawInfo.shadow != 0.0)
                return;
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = TheDepths.mod;
            TheDepthsPlayer depthPlayer = drawPlayer.GetModPlayer<TheDepthsPlayer>();
            if (depthPlayer.hasLargeGems == 0)
                return;
            BitsByte ownedLargeGems = depthPlayer.ownedLargeGems;
            BitsByte hasLargeGems = depthPlayer.hasLargeGems;
            int num1 = 0;
            for (int key = 0; key < 8; ++key)
            {
                if (ownedLargeGems[key])
                    ++num1;
                if (hasLargeGems[key])
                    ++num1;
            }
            float num2 = (float)(1.0 - num1 * 0.0450000017881393);
            float num3 = (float)((num1 - 1.0) * 4.0);
            switch (num1)
            {
                case 2:
                    num3 += 10f;
                    break;
                case 3:
                    num3 += 8f;
                    break;
                case 4:
                case 5:
                    num3 += 6f;
                    break;
                case 6:
                    num3 += 2f;
                    break;
                case 7:
                    num3 += 0.0f;
                    break;
                case 8:
                    num3 -= 2f;
                    break;
                case 9:
                    num3 -= 4f;
                    break;
                case 10:
                    num3 -= 6f;
                    break;
                case 11:
                    num3 -= 8f;
                    break;
            }
            float num4 = (float)(drawPlayer.miscCounter / 300.0 * 6.28318548202515);
            if (num1 <= 0)
                return;
            float num5 = 6.283185f / num1;
            int num6 = 0;
            List<DrawData> drawDataList = new List<DrawData>();
            string[] strArray = new string[1]
            {
                "Items/LargeOnyx_Glow",
            };
            for (int key = 0; key < 16; ++key)
            {
                if (key < 8 && !ownedLargeGems[key] || key >= 8 && !hasLargeGems[key - 8])
                {
                    ++num6;
                }
                else
                {
                    Vector2 rotationVector2 = Utils.ToRotationVector2(num4 + num5 * (key - num6));
                    Vector2 vector2 = Vector2.Add(Utils.Floor(Vector2.Add(Vector2.Subtract(drawInfo.position, Main.screenPosition), new Vector2(drawPlayer.width / 2, drawPlayer.height - 80))), Vector2.Multiply(rotationVector2, num3));
                    Texture2D texture2D = key >= 8 ? mod.GetTexture(strArray[key - 8]) : Main.gemTexture[key];
                    drawDataList.Add(new DrawData(texture2D, vector2, new Rectangle?(), new Color(250, 250, 250, Main.mouseTextColor / 2), 0.0f, Vector2.Divide(Utils.Size(texture2D), 2f), (float)(Main.mouseTextColor / 1000.0 + 0.800000011920929) * num2, 0, 0));
                }
            }
            Main.playerDrawData.AddRange(drawDataList);
        });
    }
}
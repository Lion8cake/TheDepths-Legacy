using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheDepths.Items.Banners;

namespace TheDepths.NPCs
{
    public class CrystalKing : ModNPC
    {

        public bool attacking;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal King");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults()
        {
            npc.width = 60;
            npc.height = 74;
            npc.damage = 50;
            npc.defense = 34;
            npc.lifeMax = 500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 1200f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = -1;
            banner = npc.type;
            bannerItem = ModContent.ItemType<CrystalKingBanner>();
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.velocity.Y > 0f)
            {
                npc.frame.Y = 2 * frameHeight;
            }
            else if (attacking)
            {
                npc.frame.Y = frameHeight;
            }
            else
            {
                npc.frame.Y = 0;
            }
        }

        public override void AI()
        {
            Lighting.AddLight(npc.position, 0.1f, 0.1f, 0.3f);
            npc.TargetClosest();
            Player player = Main.player[npc.target];
            Vector2 val = Main.player[npc.target].Center + new Vector2(npc.Center.X, npc.Center.Y);
            Vector2 val2 = npc.Center + new Vector2(npc.Center.X, npc.Center.Y);
            npc.netUpdate = true;
            if (player.position.X > npc.position.X)
            {
                npc.spriteDirection = 1;
            }
            else if (player.position.X < npc.position.X)
            {
                npc.spriteDirection = -1;
            }
            npc.TargetClosest();
            npc.velocity.X = npc.velocity.X * 0.93f;
            if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
            {
                npc.velocity.X = 0f;
            }
            if (npc.ai[0] == 0f)
            {
                npc.ai[0] = 500f;
            }
            if (npc.ai[2] != 0f && npc.ai[3] != 0f)
            {
                Main.PlaySound(SoundID.Item8, npc.position);
                for (int i = 0; i < 50; i++)
                {
                    int num = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 92, 0f, 0f, 100, default(Color), 1.8f);
                    Dust obj = Main.dust[num];
                    obj.velocity *= 3f;
                    Main.dust[num].noGravity = true;
                }
                npc.position.X = npc.ai[2] * 16f - (float)(npc.width / 2) + 8f;
                npc.position.Y = npc.ai[3] * 16f - (float)npc.height;
                npc.velocity.X = 0f;
                npc.velocity.Y = 0f;
                npc.ai[2] = 0f;
                npc.ai[3] = 0f;
                Main.PlaySound(SoundID.Item8, npc.position);
                for (int j = 0; j < 50; j++)
                {
                    int num2 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 92, 0f, 0f, 100, default(Color), 1.8f);
                    Dust obj2 = Main.dust[num2];
                    obj2.velocity *= 3f;
                    Main.dust[num2].noGravity = true;
                }
            }
            npc.ai[0] += 1f;
            npc.netUpdate = true;
            if (npc.ai[0] >= 650f && Main.netMode != 1)
            {
                npc.ai[0] = 1f;
                int num3 = (int)Main.player[npc.target].position.X / 16;
                int num4 = (int)Main.player[npc.target].position.Y / 16;
                int num5 = (int)npc.position.X / 16;
                int num6 = (int)npc.position.Y / 16;
                int num7 = 20;
                int num8 = 0;
                bool flag = false;
                if (Math.Abs(npc.position.X - Main.player[npc.target].position.X) + Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 2000f)
                {
                    num8 = 100;
                    flag = true;
                }
                while (!flag && num8 < 100)
                {
                    num8++;
                    int num9 = Main.rand.Next(num3 - num7, num3 + num7);
                    for (int k = Main.rand.Next(num4 - num7, num4 + num7); k < num4 + num7; k++)
                    {
                        if ((k < num4 - 4 || k > num4 + 4 || num9 < num3 - 4 || num9 > num3 + 4) && (k < num6 - 1 || k > num6 + 1 || num9 < num5 - 1 || num9 > num5 + 1) && Main.tile[num9, k].nactive())
                        {
                            bool flag2 = true;
                            if (Main.tile[num9, k - 1].lava())
                            {
                                flag2 = false;
                            }
                            if (flag2 && Main.tileSolid[Main.tile[num9, k].type] && !Collision.SolidTiles(num9 - 1, num9 + 1, k - 4, k - 1))
                            {
                                npc.ai[2] = num9;
                                npc.ai[3] = k;
                                flag = true;
                                break;
                            }
                        }
                    }
                }
                npc.netUpdate = true;
            }
            if (!player.dead && Vector2.Distance(player.Center, npc.Center) < 1000f)
            {
                npc.ai[1] += 1f;
                if (npc.ai[1] >= 150f)
                {
                    attacking = true;
                }
                if (npc.ai[1] == 150f)
                {
                    for (int l = 0; l < 10; l++)
                    {
                        Dust.NewDust(npc.position, npc.width, npc.height, 92, Main.rand.Next(-6, 6), Main.rand.Next(-6, 6), 0, default(Color), 1.4f);
                    }
                }
                if (npc.ai[1] >= 180f)
                {
                    Main.PlaySound(SoundID.Item42, npc.position);
                    float num10 = (float)Math.Atan2(val2.Y - val.Y, val2.X - val.X);
                    int num11 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Cos(num10) * 14.0 * -1.0), (float)(Math.Sin(num10) * 14.0 * -1.0), mod.ProjectileType("CrystalBall"), 25, 0f, 0);
                    Main.projectile[num11].friendly = false;
                    Main.projectile[num11].hostile = true;
                    Main.projectile[num11].timeLeft = 120;
                    attacking = false;
                    npc.ai[1] = 0f;
                }
            }
            npc.netUpdate = true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode && spawnInfo.player.ZoneUnderworldHeight && TheDepthsWorldGen.depthsorHell)
            {
                return 1.5f;
            }
            return 0f;
        }
    }
}
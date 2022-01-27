using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Projectiles.Nohitweapon
{
    public class MiracfulWhip : ModProjectile
    {
        private int soundTime;

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.alpha = byte.MaxValue;
            projectile.penetrate = -1;
            projectile.hide = true;
            projectile.tileCollide = false;
            projectile.melee = true;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            ++soundTime;
            if (soundTime == 15)
                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 15, 1f, 0.0f);
            Player player = Main.player[projectile.owner];
            float num1 = 1.570796f;
            player.RotatedRelativePoint(player.MountedCenter, true);
            if (projectile.localAI[1] > 0.0)
                --projectile.localAI[1];
            projectile.alpha -= 42;
            if (projectile.alpha < 0)
                projectile.alpha = 0;
            if (projectile.localAI[0] == 0.0)
                projectile.localAI[0] = Utils.ToRotation(projectile.velocity);
            float num2 = Utils.ToRotationVector2(projectile.localAI[0]).X >= 0.0 ? 1f : -1f;
            if (projectile.ai[1] <= 0.0)
                num2 *= -1f;
            Vector2 rotationVector2 = Utils.ToRotationVector2(num2 * (float)(projectile.ai[0] / 30.0 * 6.28318548202515 - 1.57079637050629));
            float local1 = rotationVector2.Y;
            local1 = local1* (float) Math.Sin(projectile.ai[1]);
            if (projectile.ai[1] <= 0.0)
            {
                float local2 = rotationVector2.Y;
                local2 = local2* -1f;
            }
            Vector2 vector2_1 = Utils.RotatedBy(rotationVector2, projectile.localAI[0], Vector2.Zero);
            ++projectile.ai[0];
            if (projectile.ai[0] < 30.0)
            {
                projectile.velocity = Vector2.Add(projectile.velocity, Vector2.Multiply(new Vector2(48f), vector2_1));
            }
            else
                projectile.Kill();
            projectile.position = Vector2.Subtract(player.RotatedRelativePoint(player.MountedCenter, true), Vector2.Divide(projectile.Size, 2f));
            projectile.rotation = Utils.ToRotation(projectile.velocity) + num1;
            projectile.spriteDirection = projectile.direction;
            projectile.timeLeft = 2;
            player.ChangeDir(projectile.direction);
            player.heldProj = projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = (float)Math.Atan2(projectile.velocity.Y * projectile.direction, projectile.velocity.X * projectile.direction);
            Vector2 vector2_2 = Vector2.Multiply(Main.OffsetsPlayerOnhand[player.bodyFrame.Y / 56], 2f);
            if (player.direction != 1)
            {
                vector2_2.X = player.bodyFrame.Width - vector2_2.X;
            }
            if ((double)player.gravDir != 1.0)
            {
                vector2_2.Y = player.bodyFrame.Height - vector2_2.Y;
            }
            Vector2 vector2_3 = Vector2.Subtract(vector2_2, Vector2.Divide(new Vector2((player.bodyFrame).Width - player.width, player.bodyFrame.Height - 42), 2f));
            projectile.Center = Vector2.Subtract(player.RotatedRelativePoint(Vector2.Add(player.position, vector2_3), true), projectile.velocity);
            if (projectile.alpha != 0)
                return;
            for (int index = 0; index < 2; ++index)
            {
                Dust dust = Main.dust[Dust.NewDust(Vector2.Add(projectile.position, Vector2.Multiply(projectile.velocity, 2f)), projectile.width, projectile.height, DustID.PurpleCrystalShard, 0.0f, 0.0f, 100, default, 2f)];
                dust.noGravity = true;
                dust.velocity = Vector2.Multiply(dust.velocity, 2f);
                dust.velocity = Vector2.Add(dust.velocity, Utils.ToRotationVector2(projectile.localAI[0]));
                dust.fadeIn = 1.5f;
            }
            float num3 = 18f;
            for (int index = 0; index < num3; ++index)
            {
                if (Main.rand.Next(4) == 0)
                {
                    Vector2 vector2_4 = Vector2.Add(Vector2.Add(projectile.position, projectile.velocity), Vector2.Multiply(projectile.velocity, index / num3));
                    Dust dust = Main.dust[Dust.NewDust(vector2_4, projectile.width, projectile.height, DustID.PurpleCrystalShard, 0.0f, 0.0f, 100, default, 1f)];
                    dust.noGravity = true;
                    dust.fadeIn = 0.5f;
                    dust.velocity = Vector2.Add(dust.velocity, Utils.ToRotationVector2(projectile.localAI[0]));
                    dust.noLight = true;
                }
            }
        }

        public override void CutTiles()
        {
            DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
            Vector2 velocity = projectile.velocity;
            //_ = Utils.PlotTileLine(projectile.Center, Vector2.Add(projectile.Center, Vector2.Multiply(velocity, projectile.localAI[1])), projectile.width * projectile.scale, new Utils.PerLinePoint((object)null, __methodptr(CutTiles)));
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 mountedCenter = Main.player[projectile.owner].MountedCenter;
            Color color = Lighting.GetColor((int)(projectile.position.X + projectile.width * 0.5) / 16, (int)((projectile.position.Y + projectile.height * 0.5) / 16.0));
            if (projectile.hide && !ProjectileID.Sets.DontAttachHideToAlpha[projectile.type])
                color = Lighting.GetColor((int)mountedCenter.X / 16, (int)(mountedCenter.Y / 16.0));
            Vector2 position = projectile.position;
            Vector2.Subtract(Vector2.Add(Vector2.Divide(new Vector2(projectile.width, projectile.height), 2f), Vector2.Multiply(Vector2.UnitY, projectile.gfxOffY)), Main.screenPosition);
            Texture2D texture2D = Main.projectileTexture[projectile.type];
            Color alpha = projectile.GetAlpha(color);
            if (Equals(projectile.velocity, Vector2.Zero))
                return false;
            float num1 = projectile.velocity.Length() + 16f;
            bool flag = num1 < 100.0;
            Vector2 vector2_1 = Vector2.Normalize(projectile.velocity);
            Rectangle rectangle = new Rectangle(0, 0, texture2D.Width, 42);
            Vector2 vector2_2 = new Vector2(0.0f, Main.player[projectile.owner].gfxOffY);
            float num2 = projectile.rotation + 3.141593f;
            Main.spriteBatch.Draw(texture2D, Vector2.Add(Vector2.Subtract(Utils.Floor(projectile.Center), Main.screenPosition), vector2_2), new Rectangle?(rectangle), alpha, num2, Vector2.Subtract(Vector2.Divide(Utils.Size(rectangle), 2f), Vector2.Multiply(Vector2.UnitY, 4f)), projectile.scale, 0, 0.0f);
            float num3 = num1 - 40f * projectile.scale;
            Vector2 vector2_3 = Vector2.Add(Utils.Floor(projectile.Center), Vector2.Multiply(Vector2.Multiply(vector2_1, projectile.scale), 24f));
            rectangle = new Rectangle(0, 68, texture2D.Width, 18);
            if (num3 > 0.0)
            {
                float num4 = 0.0f;
                while (num4 + 1.0 < num3)
                {
                    if ((double)num3 - num4 < (float)rectangle.Height)
                        rectangle.Height = (int)((double)num3 - num4);
                    Main.spriteBatch.Draw(texture2D, Vector2.Add(Vector2.Subtract(vector2_3, Main.screenPosition), vector2_2), new Rectangle?(rectangle), alpha, num2, new Vector2(rectangle.Width / 2, 0.0f), projectile.scale, 0, 0.0f);
                    num4 += rectangle.Height * projectile.scale;
                    vector2_3 = Vector2.Add(vector2_3, Vector2.Multiply(Vector2.Multiply(vector2_1, rectangle.Height), projectile.scale));
                }
            }
            Vector2 vector2_4 = vector2_3;
            Vector2 vector2_5 = Vector2.Add(Utils.Floor(projectile.Center), Vector2.Multiply(Vector2.Multiply(vector2_1, projectile.scale), 24f));
            rectangle = new Rectangle(0, 46, texture2D.Width, 18);
            int num5 = 18;
            if (flag)
                num5 = 9;
            float num6 = num3;
            if (num3 > 0.0)
            {
                float num4 = 0.0f;
                float num7 = num6 / num5;
                float num8 = num4 + num7 * 0.25f;
                Vector2 vector2_6 = Vector2.Add(vector2_5, Vector2.Multiply(Vector2.Multiply(vector2_1, num7), 0.25f));
                for (int index = 0; index < num5; ++index)
                {
                    float num9 = num7;
                    if (index == 0)
                        num9 *= 0.75f;
                    Main.spriteBatch.Draw(texture2D, Vector2.Add(Vector2.Subtract(vector2_6, Main.screenPosition), vector2_2), new Rectangle?(rectangle), alpha, num2, new Vector2(rectangle.Width / 2, 0.0f), projectile.scale, 0, 0.0f);
                    num8 += num9;
                    vector2_6 = Vector2.Add(vector2_6, Vector2.Multiply(vector2_1, num9));
                }
            }
            rectangle = new Rectangle(0, 90, texture2D.Width, 48);
            Main.spriteBatch.Draw(texture2D, Vector2.Add(Vector2.Subtract(vector2_4, Main.screenPosition), vector2_2), new Rectangle?(rectangle), alpha, num2, Utils.Top(Utils.Frame(texture2D, 1, 1, 0, 0)), projectile.scale, 0, 0.0f);
            return false;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            if (projHitbox.Intersects(targetHitbox))
                return new bool?(true);
            float num = 0.0f;
            return Collision.CheckAABBvLineCollision(Utils.TopLeft(targetHitbox), Utils.Size(targetHitbox), projectile.Center, Vector2.Add(projectile.Center, (Vector2)projectile.velocity), 16f * projectile.scale, ref num) ? new bool?(true) : new bool?(false);
        }
    }
}

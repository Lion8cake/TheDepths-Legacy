using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheDepths.Projectiles.Nohitweapon
{
    public class MiracfulSparkle : ModProjectile
    {
        int timer = 0;
        public override void SetDefaults()
        {
            projectile.width = 72;
            projectile.height = 72;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = 10;
            projectile.tileCollide = false;
            projectile.timeLeft = 800;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < Main.rand.Next(3, 5); i++)
            {
                Dust.NewDust(projectile.Center, 8, 8, 91);
            }
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, Color.White.ToVector3());
            projectile.rotation += 0.4f;
            if (++timer > 40)
                projectile.velocity *= 0.97f;

            if (projectile.timeLeft < 100)
            {
                projectile.scale *= 0.98f;
                projectile.rotation *= 0.98f;
            }

            if (Main.rand.NextBool(15))
            {
                for (int i = 0; i < Main.rand.Next(3, 5); i++)
                {
                    Dust.NewDust(projectile.Center, 8, 8, 91);
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.penetrate--;
            if (projectile.penetrate > 0)
                projectile.Kill();
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}

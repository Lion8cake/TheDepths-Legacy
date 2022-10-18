using Terraria;
using Terraria.ModLoader;

namespace TheDepths.Projectiles.Nohitweapon
{
    public class MiracfulSnake : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            projectile.width = 62;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.timeLeft = 400;
            projectile.penetrate = -1;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[target.whoAmI] = 5;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.immuneTime = 5;
        }

        public override void AI()
        {
            if (++projectile.frameCounter >= 4)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
        }
    }
}

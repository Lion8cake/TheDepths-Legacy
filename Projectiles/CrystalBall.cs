using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Projectiles
{
	public class CrystalBall : ModProjectile
	{
		public override void SetDefaults() {
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.penetrate = 8;
			projectile.timeLeft = 850;
			projectile.alpha = 255; 
		}

		public override void AI()
	{
		if (projectile.alpha > 0)
		{
			projectile.alpha -= 25;
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
		}
		Lighting.AddLight(projectile.Center, (float)(255 - projectile.alpha) * 0.01f / 255f, (float)(255 - projectile.alpha) * 0.3f / 255f, (float)(255 - projectile.alpha) * 0.45f / 255f);
		for (int num103 = 0; num103 < 2; num103++)
		{
			float num104 = projectile.velocity.X / 3f * (float)num103;
			float num100 = projectile.velocity.Y / 3f * (float)num103;
			int num101 = 4;
			int frostDust = Dust.NewDust(new Vector2(projectile.position.X + (float)num101, projectile.position.Y + (float)num101), projectile.width - num101 * 2, projectile.height - num101 * 2, 92, 0f, 0f, 100, default(Color), 1.2f);
			Dust obj = Main.dust[frostDust];
			obj.noGravity = true;
			obj.velocity *= 0.1f;
			obj.velocity += projectile.velocity * 0.1f;
			obj.position.X -= num104;
			obj.position.Y -= num100;
		}
		if (Main.rand.NextBool(10))
		{
			int num102 = 4;
			int frostDustSmol = Dust.NewDust(new Vector2(projectile.position.X + (float)num102, projectile.position.Y + (float)num102), projectile.width - num102 * 2, projectile.height - num102 * 2, 92, 0f, 0f, 100, default(Color), 0.6f);
			Dust obj2 = Main.dust[frostDustSmol];
			obj2.velocity *= 0.25f;
			Dust obj3 = Main.dust[frostDustSmol];
			obj3.velocity += projectile.velocity * 0.5f;
		}
		projectile.rotation += 0.3f * (float)projectile.direction;
	}

		public override bool OnTileCollide(Vector2 oldVelocity) {
			projectile.penetrate--;
			if (projectile.penetrate <= 0) {
				projectile.Kill();
			}
			else {
				projectile.ai[0] += 0.1f;
				if (projectile.velocity.X != oldVelocity.X) {
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y) {
					projectile.velocity.Y = -oldVelocity.Y;
				}
				projectile.velocity *= 0.75f;
				Main.PlaySound(SoundID.Item10, projectile.position);
			}
			return false;
		}

		public override void Kill(int timeLeft) {
			for (int k = 0; k < 5; k++) {
			}
			Main.PlaySound(SoundID.Item10, projectile.position);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
		}
	}
}
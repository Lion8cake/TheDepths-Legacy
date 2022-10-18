using TheDepths.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Projectiles
{
	public class ShadowBall : ModProjectile
	{
		public override void SetDefaults() {
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 2;
			projectile.timeLeft = 250;
			projectile.aiStyle = 8;
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
			int shadowDust = Dust.NewDust(new Vector2(projectile.position.X + (float)num101, projectile.position.Y + (float)num101), projectile.width - num101 * 2, projectile.height - num101 * 2, 27, 0f, 0f, 100, default(Color), 1.2f);
			Dust obj = Main.dust[shadowDust];
			obj.noGravity = true;
			obj.velocity *= 0.1f;
			obj.velocity += projectile.velocity * 0.1f;
			obj.position.X -= num104;
			obj.position.Y -= num100;
		}
		if (Main.rand.NextBool(10))
		{
			int num102 = 4;
			int shadowDustSmol = Dust.NewDust(new Vector2(projectile.position.X + (float)num102, projectile.position.Y + (float)num102), projectile.width - num102 * 2, projectile.height - num102 * 2, 27, 0f, 0f, 100, default(Color), 0.6f);
			Dust obj2 = Main.dust[shadowDustSmol];
			obj2.velocity *= 0.25f;
			Dust obj3 = Main.dust[shadowDustSmol];
			obj3.velocity += projectile.velocity * 0.5f;
		}
		projectile.rotation += 0.3f * (float)projectile.direction;
	}

		public override bool OnTileCollide(Vector2 oldVelocity) {
			projectile.penetrate--;
			if (projectile.penetrate <= 0) {
				projectile.Kill();
			}
			return false;
		}

		public override void Kill(int timeLeft)
	{
		if (Main.myPlayer != projectile.owner)
		{
			return;
		}
		int choice = Main.rand.Next(1);
		if (choice == 0)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ModContent.ProjectileType<ShadowBall2>(), 24, 1f, Main.myPlayer, 0f, 0f);
		}
		
		int num = Main.rand.Next(1);
		if (num == 0)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ModContent.ProjectileType<ShadowBall2>(), 24, 1f, Main.myPlayer, 0f, 0f);
		}
	}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
		}
	}
}
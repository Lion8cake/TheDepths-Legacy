using TheDepths.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Projectiles
{
	public class DiamondArrow : ModProjectile
	{
		public override void SetDefaults() {
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 600;
		}

		public override void AI() {
			projectile.ai[0] += 1f;
			projectile.direction = projectile.spriteDirection = projectile.velocity.X > 0f ? 1 : -1;
			projectile.rotation = projectile.velocity.ToRotation();
			if (projectile.velocity.Y > 16f) {
				projectile.velocity.Y = 16f;
			}
			if (projectile.spriteDirection == -1) {
				projectile.rotation += MathHelper.Pi;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
		}
		
		public override void Kill(int timeLeft)
	{
		Main.PlaySound(SoundID.Item14, projectile.position);
		if (Main.myPlayer != projectile.owner)
		{
			return;
		}
		int choice = Main.rand.Next(1);
		if (choice == 0)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ModContent.ProjectileType<CrystalBallPassive>(), 24, 1f, Main.myPlayer, 0f, 0f);
		}
		
		int num = Main.rand.Next(1);
		if (num == 0)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ModContent.ProjectileType<CrystalBallPassive>(), 24, 1f, Main.myPlayer, 0f, 0f);
		}
		
		int num2 = Main.rand.Next(1);
		if (num2 == 0)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ModContent.ProjectileType<CrystalBallPassive>(), 24, 1f, Main.myPlayer, 0f, 0f);
		}
	}
	}
}
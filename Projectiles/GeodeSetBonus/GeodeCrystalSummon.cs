using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Projectiles.GeodeSetBonus
{
	public class GeodeCrystalSummon : ModProjectile
	{
	public bool shift;

	public bool shift2;

	public int timer;

	public float rot;
	
	public float fadeOut = 0.75f;

	public override void SetDefaults()
	{
		projectile.width = 18;
		projectile.height = 26;
		projectile.aiStyle = -1;
		projectile.friendly = true;
		projectile.tileCollide = false;
		projectile.ignoreWater = true;
		projectile.penetrate = -1;
		projectile.timeLeft = 60;
		ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[projectile.type] = 0;
	}

	public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
	{
		Player player = Main.player[projectile.owner];
		hitDirection = ((!(target.Center.X < player.Center.X)) ? 1 : (-1));
	}
	
	public override Color? GetAlpha(Color lightColor)
	{
		return new Color(255, 255, 255, 100) * fadeOut;
	}

	public static Vector2 RotateVector(Vector2 origin, Vector2 vecToRot, float rot)
	{
		float num = (float)(Math.Cos(rot) * (double)(vecToRot.X - origin.X) - Math.Sin(rot) * (double)(vecToRot.Y - origin.Y) + (double)origin.X);
		float num2 = (float)(Math.Sin(rot) * (double)(vecToRot.X - origin.X) + Math.Cos(rot) * (double)(vecToRot.Y - origin.Y) + (double)origin.Y);
		return new Vector2(num, num2);
	}

	public override void AI()
    {
		Player player = Main.player[projectile.owner];
		rot += 0.03f;
		projectile.Center = player.Center + RotateVector(default(Vector2), new Vector2(0f, (float)(90 + projectile.frameCounter)), rot + projectile.ai[0] * 1.04666674f);
		projectile.velocity.X = ((projectile.position.X > player.position.X) ? 1f : (-1f));
		if (projectile.ai[1] == 0f)
		{
			projectile.friendly = true;
			fadeOut = 0.15f;
			projectile.alpha = 0;
			timer = 0;
		}
		else
		{
			projectile.friendly = false;
			fadeOut = 0.15f;
			projectile.alpha += ((!shift2) ? 5 : (-5));
			if (projectile.alpha > 225 && !shift2)
			{
				shift2 = true;
			}
			if (projectile.alpha <= 125)
			{
				shift2 = false;
			}
			timer++;
			if (timer > 180)
			{
				projectile.ai[1] = 0f;
				timer = 0;
			}
		}
	}
	}
}
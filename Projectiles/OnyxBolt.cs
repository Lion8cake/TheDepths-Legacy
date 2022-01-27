using TheDepths.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Projectiles
{
	public class OnyxBolt : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.width = 10;
		projectile.height = 10;
		projectile.alpha = 255;
		projectile.penetrate = 2;
		projectile.friendly = true;
		projectile.magic = true;
	}

	public override void AI()
	{
		for (int i = 0; i < 2; i++)
		{
			int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("BlackGemsparkDust"), projectile.velocity.X, projectile.velocity.Y, 150, default(Color), 1.25f);
			Main.dust[num].noGravity = true;
			Dust obj = Main.dust[num];
			obj.velocity *= 0.3f;
		}
	}

	public override void Kill(int timeLeft)
	{
		for (int i = 0; i < 8; i++)
		{
			int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("BlackGemsparkDust"), projectile.velocity.X * 0.75f, projectile.velocity.Y * 0.75f, 150);
			Main.dust[num].noGravity = true;
		}
	}
}
}
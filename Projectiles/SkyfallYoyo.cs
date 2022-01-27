using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Projectiles
{
	public class SkyfallYoyo : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 16f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 230f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 10f;
		}

		public override void SetDefaults() {
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
			target.AddBuff(ModContent.BuffType<Buffs.MercuryBoiling>(), 250, false);
		}

		public override void OnHitPvp(Player target, int damage, bool crit) {
		target.AddBuff(ModContent.BuffType<Buffs.MercuryBoiling>(), 250, false);
		}
	}
}

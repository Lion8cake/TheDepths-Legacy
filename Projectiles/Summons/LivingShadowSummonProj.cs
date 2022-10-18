using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TheDepths;
using TheDepths.Tiles;
using TheDepths.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.World.Generation;
using TheDepths.Dusts;
using TheDepths.Projectiles.Summons;
using TheDepths.Buffs;

namespace TheDepths.Projectiles.Summons
{
    public class LivingShadowSummonProj : ModProjectile
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Silhouette");
		Main.projFrames[projectile.type] = 15;
		ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
	}

	public override void SetDefaults()
	{
		projectile.CloneDefaults(394);
		projectile.width = 30;
		projectile.height = 46;
		projectile.aiStyle = 67;
		projectile.friendly = true;
		projectile.scale = 1f;
		projectile.timeLeft = 18000;
		projectile.penetrate = -1;
		projectile.timeLeft *= 5;
		projectile.minionSlots = 1f;
		drawOriginOffsetY = -6;
		aiType = 394;
		projectile.usesLocalNPCImmunity = true;
		projectile.localNPCHitCooldown = 15;
	}

	public override void AI()
	{
		Player player = Main.player[projectile.owner];
		    #region Active check
			if (player.dead || !player.active) {
				player.ClearBuff(ModContent.BuffType<LivingShadowSummonBuff>());
			}
			if (player.HasBuff(ModContent.BuffType<LivingShadowSummonBuff>())) {
				projectile.timeLeft = 2;
			}
			#endregion
		if (projectile.localAI[0] >= 800f)
		{
			projectile.localAI[0] = 0f;
		}
		if (Vector2.Distance(player.Center, projectile.Center) > 600f)
		{
			projectile.position.X = player.position.X;
			projectile.position.Y = player.position.Y;
		}
	}

	public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
	{
		fallThrough = false;
		return true;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		return false;
	}
}
}

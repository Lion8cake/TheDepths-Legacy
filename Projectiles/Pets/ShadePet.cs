using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Projectiles.Pets
{
	public class ShadePet : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
		}

		public override bool PreAI() {
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false;
			return true;
		}

		public override void AI() {
			Player player = Main.player[projectile.owner];
			TheDepthsPlayer modPlayer = player.GetModPlayer<TheDepthsPlayer>();
			if (player.dead) {
				modPlayer.ShadePet = false;
			}
			if (modPlayer.ShadePet) {
				projectile.timeLeft = 2;
			}
		}
	}
}
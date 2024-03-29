using Terraria;
using Terraria.ModLoader;

namespace TheDepths.Buffs
{
	public class ShadePetBuff : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Shade Pet");
			Description.SetDefault("\"A Shade is floating around with you!\"");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<TheDepthsPlayer>().ShadePet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.ShadePet>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.ShadePet>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}
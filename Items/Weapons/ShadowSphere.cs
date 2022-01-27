using TheDepths.Projectiles;
using TheDepths.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Items.Weapons
{
	public class ShadowSphere : ModItem
	{
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			item.damage = 38;
			item.magic = true;
			item.mana = 10;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item21;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<ShadowBall>();
			item.shootSpeed = 7.5f;
		}
	}
}
using TheDepths.Projectiles.Summons;
using TheDepths.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDepths.Items.Weapons
{
	public class LivingShadowStaff : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Summons a Silhouette to fight for you");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults() {
			item.damage = 25;
			item.summon = true;
			item.mana = 10;
			item.width = 26;
			item.height = 28;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = Item.buyPrice(0, 0, 100, 0);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item44;
			item.shoot = ModContent.ProjectileType<LivingShadowSummonProj>();
			item.buffType = ModContent.BuffType<Buffs.LivingShadowSummonBuff>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}
	}
}

using TheDepths.Dusts;
using TheDepths.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheDepths.Projectiles;

namespace TheDepths.Items.Weapons
{
	public class SapphireShovel : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Disables enemies for a few seconds.");
		}

		public override void SetDefaults() {
			item.damage = 20;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 30;
			item.useAnimation = 30; 
			item.knockBack = 15;
			item.value = Item.buyPrice(gold: 5);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1; 
			item.autoReuse = true;
			item.crit = 4;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.shoot = ModContent.ProjectileType<SapphireShovelProj>();
			item.shootSpeed = 7.5f;
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(ModContent.BuffType<Buffs.FreezingWater>(), 150);
		}
	}
}

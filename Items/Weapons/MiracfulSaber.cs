using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TheDepths.Projectiles.Nohitweapon;

namespace TheDepths.Items.Weapons
{
	public class MiracfulSaber : ModItem
	{
		public int swings = 0;
		public int mode = 0;

		public override bool CloneNewInstances => true;
		public override ModItem Clone()
		{
			var clone = (MiracfulSaber)base.Clone();
			clone.swings = swings;
			clone.mode = mode;
			return clone;
		}
		public override ModItem Clone(Item item)
		{
			MiracfulSaber itemClone = (MiracfulSaber)base.Clone(item);
			itemClone.swings = swings;
			itemClone.mode = mode;
			return itemClone;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Miracful Saber");
			Tooltip.SetDefault($@"Changes blade color every 14 swings
There are 8 weapon modes in total
[c/A500EC:Amethyst Mode]: Transforms in amethyst whip
[c/F19F01:Topaz Mode]: Shoots 4-6 hot fire every swing
[c/0D6BD8:Sapphire Mode]: Sword now able to freeze enemies!
[c/21B873:Emerald Mode]: Power of nature blesses your weapon...
[c/C3292C:Ruby Mode]: Sword begins to shoot crimson musical notes
[c/DFE6EE:Diamond Mode]: Blade becomes so shiny, so it begins to shoot with sparkles!
[c/D58E30:Amber Mode]: Shoots with amber snakes those able to deal colossal damage
[c/393940:Onyx Mode]: Shoots 5 onyx blasters");
		}

		public override void SetDefaults()
		{
			item.knockBack = 2f;
			item.width = 48;
			item.height = 48;
			item.useTime = 14;
			item.useAnimation = 14;
			item.damage = 45;
			item.crit += 10;
			item.rare = ItemRarityID.Cyan;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.shoot = ProjectileID.None;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
			swings = 0;
			mode = 0;
		}

		private void SwingsHahaSoFunny()
		{
			if (mode == 0)
			{
				item.noUseGraphic = true;
				item.noMelee = true;
				item.shoot = ModContent.ProjectileType<MiracfulWhip>();
				item.shootSpeed = 15f;
			}
			else if (mode == 1)
			{
				item.noUseGraphic = false;
				item.noMelee = false;
				item.shoot = ProjectileID.Fireball;
				item.shootSpeed = 7f;
			}
			else if (mode == 2)
			{
				item.shoot = ModContent.ProjectileType<MiracfulSapphire>();
				item.shootSpeed = 5f;
			}
			else if (mode == 3)
			{
				item.shoot = ProjectileID.CrystalLeafShot;
				item.shootSpeed = 10f;
			}
			else if (mode == 4)
			{
				item.shoot = ModContent.ProjectileType<MiracfulCrimson1>();
				item.shootSpeed = 5f;
			}
			else if (mode == 5)
			{
				item.shoot = ModContent.ProjectileType<MiracfulSparkle>();
				item.shootSpeed = 8f;
			}
			else if (mode == 6)
            {
				item.shoot = ModContent.ProjectileType<MiracfulSnake>();
				item.shootSpeed = 6f;
            }
			else if (mode == 7)
			{
				item.shoot = ProjectileID.BlackBolt;
				item.shootSpeed = 8f;
            }
			else
			{
				item.noUseGraphic = false;
				item.noMelee = false;
				item.shoot = ProjectileID.None;
				item.shootSpeed = 0f;
			}

            swings++;
			if (swings > 14)
			{
				mode++;
				if (mode > 7)
				{
					mode = 0;
				}
				swings = 0;
			}
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			SwingsHahaSoFunny();

			Vector2 speed = new Vector2(speedX, speedY);
            switch (mode)
            {
				case 0: // Amethyst
					float num = (float)((Main.rand.NextFloat() - 0.75) * 0.785398185253143);
					Projectile.NewProjectile(position, speed, ModContent.ProjectileType<MiracfulWhip>(), damage, knockBack, player.whoAmI, 0f, num);
					break;
				case 1: // Topaz
					speedX *= Main.rand.NextFloat(0.5f, 1.5f);
					speedY *= Main.rand.NextFloat(0.5f, 1.5f);
					int[] num2 = new int[6] { 0, 0, 0, 0, 0, 0, };
					for (int i = 0; i < Main.rand.Next(4, 6); i++)
					{
						if (Main.rand.NextBool(2))
							num2[i] = Projectile.NewProjectile(position, speed.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 75))), ProjectileID.Fireball, damage, knockBack, player.whoAmI);
						else
							num2[i] = Projectile.NewProjectile(position, speed.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(-75, -5))), ProjectileID.Fireball, damage, knockBack, player.whoAmI);
						Main.projectile[num2[i]].friendly = true;
						Main.projectile[num2[i]].hostile = false;
					}
					break;
				case 2: // Sapphire
					Projectile.NewProjectile(position, speed, ModContent.ProjectileType<MiracfulSapphire>(), damage, knockBack, player.whoAmI);
					break;
				case 3: // Emerald
					int[] num3 = new int[6] { 0, 0, 0, 0, 0, 0, };
					for (int i = 0; i < Main.rand.Next(4, 6); i++)
					{
						if (Main.rand.NextBool(2))
							num3[i] = Projectile.NewProjectile(position, speed.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 75))), ProjectileID.CrystalLeafShot, damage, knockBack, player.whoAmI);
						else
							num3[i] = Projectile.NewProjectile(position, speed.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(-75, -5))), ProjectileID.CrystalLeafShot, damage, knockBack, player.whoAmI);
						Main.projectile[num3[i]].friendly = true;
						Main.projectile[num3[i]].hostile = false;
					}
					break;
				case 4: // Ruby
					speedX *= Main.rand.NextFloat(0.5f, 1.5f);
					speedY *= Main.rand.NextFloat(0.5f, 1.5f);
					if (Main.rand.NextBool(3)) type = ModContent.ProjectileType<MiracfulCrimson1>();
					else if (Main.rand.NextBool(3)) type = ModContent.ProjectileType<MiracfulCrimson2>();
					else type = ModContent.ProjectileType<MiracfulCrimson3>();
					Projectile.NewProjectile(position, speed, type, damage, knockBack, player.whoAmI);
                    break;
                case 5: // Diamond
                    Projectile.NewProjectile(position, speed, ModContent.ProjectileType<MiracfulSparkle>(), damage, knockBack, player.whoAmI);
                    break;
				case 6: // Amber
					Projectile.NewProjectile(position, speed, ModContent.ProjectileType<MiracfulSnake>(), damage, knockBack, player.whoAmI);
					break;
				case 7: // Onyx
					for (int i = 0; i < Main.rand.Next(2, 4); i++)
					{
						if (Main.rand.NextBool(2))
							Projectile.NewProjectile(position, speed.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(45, 135))), ProjectileID.BlackBolt, damage, knockBack, player.whoAmI);
						else
							Projectile.NewProjectile(position, speed.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(-135, -45))), ProjectileID.BlackBolt, damage, knockBack, player.whoAmI);
					}
                    Projectile.NewProjectile(position, speed, ProjectileID.BlackBolt, damage, knockBack, player.whoAmI);
					break;
            }
            return false;
		}

		public override bool UseItem(Player player) //KEEP IT
		{
			SwingsHahaSoFunny();
			return true;
		}

        public override Color? GetAlpha(Color lightColor)
		{
			Color[] itemNameCycleColors = new Color[]
			{
				new Color(165, 0, 236),
				new Color(241, 159, 1),
				new Color(13, 107, 216),
				new Color(33, 184, 115),
				new Color(195, 41, 44),
				new Color(223, 230, 238),
				new Color(213, 142, 48),
				new Color(57, 57, 64),
			};
			float fade = Main.GameUpdateCount % 80 / 60f;
			int index = (int)(Main.GameUpdateCount / 80 % itemNameCycleColors.Length);
			Color color = Color.Lerp(itemNameCycleColors[index], itemNameCycleColors[(index + 1) % itemNameCycleColors.Length], fade);
			return Color.Lerp(color, lightColor, 0.2f);
		}


		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			Color[] itemNameCycleColors = new Color[]
			{
				new Color(165, 0, 236),
				new Color(241, 159, 1),
				new Color(13, 107, 216),
				new Color(33, 184, 115),
				new Color(195, 41, 44),
				new Color(223, 230, 238),
				new Color(213, 142, 48),
				new Color(57, 57, 64),
			};
			foreach (TooltipLine line2 in tooltips)
			{
				if (line2.mod == "Terraria" && line2.Name == "ItemName")
				{
					float fade = Main.GameUpdateCount % 80 / 60f;
					int index = (int)(Main.GameUpdateCount / 80 % itemNameCycleColors.Length);
					line2.overrideColor = Color.Lerp(itemNameCycleColors[index], itemNameCycleColors[(index + 1) % itemNameCycleColors.Length], fade);
				}
			}
		}

		#region Save, Load, NetSend, NetReceive
		public override TagCompound Save()
		{
			return new TagCompound
			{
				[nameof(swings)] = swings,
				[nameof(mode)] = mode,
			};
		}

		public override void Load(TagCompound tag)
		{
			swings = tag.GetInt(nameof(swings));
			mode = tag.GetInt(nameof(mode));
		}

		public override void NetSend(BinaryWriter writer)
		{
			writer.Write(swings);
			writer.Write(mode);
		}

		public override void NetRecieve(BinaryReader reader)
		{
			swings = reader.ReadInt32();
			mode = reader.ReadInt32();
		}
		#endregion
	}
}

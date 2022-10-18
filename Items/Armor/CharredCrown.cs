using TheDepths.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheDepths.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CharredCrown : ModItem
	{
		public override void SetStaticDefaults() {
		Tooltip.SetDefault("18% Increased Magic Damage");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.rare = ItemRarityID.Orange;
			item.defense = 8;
			item.value = 100000;
		}
		
		public override void UpdateEquip(Player player) {
		player.magicDamage += 0.18f;
		}
	}
}
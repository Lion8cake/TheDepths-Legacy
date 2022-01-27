using TheDepths.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheDepths.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CrystalCrown : ModItem
	{
		public override void SetStaticDefaults() {
		Tooltip.SetDefault("20% Increased Magic Critical Strike Chance");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.rare = ItemRarityID.Orange;
			item.defense = 6;
			item.value = 100000;
		}
		
		public override void UpdateEquip(Player player) {
		player.magicCrit += 20;
		}
	}
}
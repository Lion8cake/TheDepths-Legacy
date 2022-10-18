using TheDepths.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheDepths.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class PurplePlumbersHat : ModItem
	{ 
	    public override void SetStaticDefaults() {
			DisplayName.SetDefault("Purple Plumber's Hat");
		}
		
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.rare = ItemRarityID.White;
			item.vanity = true;
			item.value = 10000;
		}
	}
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using Terraria.Utilities;

namespace TheDepths.Buffs
{
	public class CrystalSkin : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Crystal Skin");
			Description.SetDefault("Immune to Quicksilver");
			Main.debuff[Type] = false;
	    	Main.pvpBuff[Type] = true;
	    	Main.buffNoSave[Type] = false;
	    	longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex) {
		player.buffImmune[ModContent.BuffType<MercuryPoisoning>()] = true;
		player.buffImmune[ModContent.BuffType<MercuryBoiling>()] = true;
		}
	}
}

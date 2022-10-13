using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheDepths.Items.Banners;

namespace TheDepths.NPCs
{
	public class GoldBat : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Gold Bat");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults() {
			npc.width = 28;
			npc.height = 28;
			npc.damage = 25;
			npc.defense = 10;
			npc.lifeMax = 320;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.lavaImmune = true;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 14;
			aiType = NPCID.GiantBat;
			animationType = NPCID.GiantBat;
			banner = npc.type;
			bannerItem = ModContent.ItemType<GoldBatBanner>();
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.player.ZoneUnderworldHeight && TheDepthsWorldGen.depthsorHell)
			{
				return 1.5f;
			}
			return 0f;
		}
	}
}

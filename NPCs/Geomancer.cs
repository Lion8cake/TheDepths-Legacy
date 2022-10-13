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
	public class Geomancer : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Geomancer");
			Main.npcFrameCount[npc.type] = 16; 
		}

		public override void SetDefaults() {
			npc.width = 40;
			npc.height = 80;
			npc.damage = 40;
			npc.defense = 16;
			npc.lifeMax = 85;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			//Sound 3 and 4 
			npc.lavaImmune = true;
			npc.value = 700f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = NPCID.ChaosElemental;
			animationType = NPCID.ChaosElemental;
			banner = npc.type;
			bannerItem = ModContent.ItemType<GeomancerBanner>();
		}
		
		public override void HitEffect(int hitDirection, double damage) {
			if (npc.life <= 0)
		{
			Gore.NewGore(npc.position, npc.velocity, 13);
			Gore.NewGore(npc.position, npc.velocity, 12);
			Gore.NewGore(npc.position, npc.velocity, 11);
		}
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

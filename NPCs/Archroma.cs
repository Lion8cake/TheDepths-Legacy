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
	public class Archroma : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Archroma");
			Main.npcFrameCount[npc.type] = 2; 
		}
		
		public override void SetDefaults() {
			npc.width = 24;
			npc.height = 24;
			npc.damage = 75;
			npc.defense = 35;
			npc.lifeMax = 800;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 250000f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 1;
			aiType = NPCID.Crimslime;
			animationType = NPCID.Crimslime;
			banner = npc.type;
			bannerItem = ModContent.ItemType<AchromaBanner>();
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (Main.hardMode && spawnInfo.player.ZoneUnderworldHeight && TheDepthsWorldGen.depthsorHell)
			{
				return 1.5f;
			}
			return 0f;
		}
	}
}
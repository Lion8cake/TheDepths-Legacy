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
	public class ShadowBat : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Shadow Bat");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults() {
			npc.width = 48;
			npc.height = 40;
			npc.damage = 62;
			npc.defense = 18;
			npc.lifeMax = 220;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 400f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 14;
			aiType = NPCID.GiantBat;
			animationType = NPCID.GiantBat;
			banner = npc.type;
			bannerItem = ModContent.ItemType<ShadowBatBanner>();
		}
		
		public override void OnHitPlayer(Player target, int damage, bool crit)
    	{
    		target.AddBuff(BuffID.Blackout, 180);
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

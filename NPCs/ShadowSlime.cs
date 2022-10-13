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
	public class ShadowSlime : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Shadow Slime");
			Main.npcFrameCount[npc.type] = 2; 
		}
		
		public override void SetDefaults() {
			npc.width = 32;
			npc.height = 32;
			npc.damage = 34;
			npc.defense = 12;
			npc.lifeMax = 55;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 400f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 1;
			aiType = NPCID.Crimslime;
			animationType = NPCID.Crimslime;
			npc.lavaImmune = true;
			banner = npc.type;
			bannerItem = ModContent.ItemType<ShadowSlimeBanner>();
		}
		
		public override void OnHitPlayer(Player target, int damage, bool crit)
    	{
    		target.AddBuff(BuffID.Darkness, 180);
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
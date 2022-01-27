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
	public class Ferroslime : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ferroslime");
			Main.npcFrameCount[npc.type] = 2; 
		}
		
		public override void SetDefaults() {
			npc.width = 40;
			npc.height = 40;
			npc.damage = 90;
			npc.defense = 28;
			npc.lifeMax = 450;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 1;
			aiType = NPCID.Crimslime;
			animationType = NPCID.Crimslime;
			banner = npc.type;
			bannerItem = ModContent.ItemType<FerroslimeBanner>();
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
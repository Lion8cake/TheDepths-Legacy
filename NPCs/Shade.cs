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
    public class Shade : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shade");
        }

        public override void SetDefaults()
        {
            npc.width = 56;
            npc.height = 70;
            npc.damage = 46;
            npc.defense = 10;
            npc.lifeMax = 140;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 300f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 22;
            aiType = NPCID.FloatyGross;
            banner = npc.type;
            bannerItem = ModContent.ItemType<ShadeBanner>();
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
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

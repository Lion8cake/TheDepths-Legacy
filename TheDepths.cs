using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using MonoMod.Cil;
using Terraria;
using Terraria.ModLoader;
using TheDepths.Tiles;

namespace TheDepths
{
    public class TheDepths : Mod
    {
        public static readonly Texture2D[] texture = new Texture2D[5];
        public static Mod mod;
        public static List<int> livingFireBlockList;

        public override void Load()
        {
            mod = this;
            IL.Terraria.Main.DrawMenu += Hooks.DepthsWorldCreationUI.ILDrawMenu;
            IL.Terraria.Main.DrawUnderworldBackground += Main_DrawUnderworldBackground;
            livingFireBlockList = new List<int> { 336, 340, 341, 342, 343, 344, ModContent.TileType<LivingFog>() };
            if (!Main.dedServ)
            {
                AddEquipTexture(null, EquipType.Legs, "OnyxRobe_Legs", "TheDepths/Items/Armor/OnyxRobe_Legs");
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Depths"), ItemType("DepthsMusicBox"), TileType("DepthsMusicBox"));
            }
            for (int i = 0; i < texture.Length; i++)
                texture[i] = ModContent.GetTexture("TheDepths/Backgrounds/DepthsUnderworldBG_" + i);
        }

        private void Main_DrawUnderworldBackground(ILContext il)
        {
            var c = new ILCursor(il);
            if (!c.TryGotoNext(i => i.MatchLdcI4(4)))
                return;
            if (!c.TryGotoNext(i => i.MatchLdsfld(out _)))
                return;
            c.Index++;
            c.EmitDelegate<Func<Texture2D[], Texture2D[]>>((orig) =>
            {
                if (TheDepthsWorldGen.depthsorHell)
                    return texture;
                return orig;
            });
        }

        public override void Unload()
        {
            livingFireBlockList = null;
        }
		
		public override void UpdateMusic(ref int music, ref MusicPriority priority) {
			if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active) {
				return;
			}
			if (Main.LocalPlayer.GetModPlayer<TheDepthsPlayer>().ZoneDepths) {
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/Depths");
				priority = MusicPriority.Environment;
			}
		}
    }
}
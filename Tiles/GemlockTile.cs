using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TheDepths.Tiles
{
    public class GemlockTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true;
            TileID.Sets.AvoidedByNPCs[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
			TileID.Sets.FramesOnKillWall[Type] = true;
            TileObjectData.addTile(Type);
			disableSmartCursor = true;
            dustType = 7;
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("");
            AddMapEntry(new Color(120, 120, 120), name);
        }
        public override bool HasSmartInteract()
        {
            return true;
        }
        public static void ShowItemIcon(int tX, int tY, int itemType)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.showItemIcon = true;
            player.showItemIcon2 = itemType;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int gemLock = 0;
            int gem = SelectGem((short)frameX);
            switch (frameX / 54)
            {
                case 0:
                    gemLock = mod.ItemType("OnyxGemLock");
                    break;
            }
            if (gemLock > 0)
            {
                Item.NewItem(i * 16, j * 16, 54, 32, gemLock);
                if (frameY >= 54)
				{
                    Item.NewItem(i * 16, j * 16, 54, 32, gem);
				}
            }
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            bool IsOn = Main.tile[i, j].frameY / 54 == 1;
            int gem = SelectGem(Main.tile[i, j].frameX);
            if (gem > 0 && (IsOn || player.HasItem(gem)))
            {
                player.noThrow = 2;
                player.showItemIcon = true;
                player.showItemIcon2 = gem;
            }
        }

        public override bool NewRightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            bool IsOn = Main.tile[i, j].frameY / 54 == 1;
            int gem = SelectGem(Main.tile[i, j].frameX);
            if (!IsOn && player.selectedItem != 58 && gem > 0 && player.ConsumeItem(gem) || IsOn)
            {
                player.GamepadEnableGrappleCooldown();
                if (Main.netMode != NetmodeID.MultiplayerClient)
                    Toggle(i, j, !IsOn);
                else
                {
                    ModPacket packet = mod.GetPacket(255);
                    packet.Write((byte)0);
                    packet.Write((short)i);
                    packet.Write((short)j);
                    packet.Write(!IsOn);
                    packet.Send();
                }
            }
            return true;
        }

        public static void Toggle(int i, int j, bool turnOn)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            Mod mod = ModLoader.GetMod("TheDepths");
            if (!tile.active() || tile.type != mod.TileType("GemlockTile"))
                return;

            bool IsOn = tile.frameY / 54 == 1;
            if (IsOn == turnOn)
                return;
            
            int left = i - Main.tile[i, j].frameX % 54 / 18;
            int top = j - Main.tile[i, j].frameY % 54 / 18;

            for (int k = left; k < left + 3; k++)
            {
                for (int l = top; l < top + 3; l++)
                {
                    Main.tile[k, l].frameY = (short)((Main.tile[k, l].frameY + 54) % 108);
                }
            }
            
            if (!turnOn)
            {
                int gem = SelectGem(Main.tile[i, j].frameX);
                if (gem > 0)
                    Item.NewItem(i * 16, j * 16, 32, 32, gem);
            }

            WorldGen.SquareTileFrame(i, j);
            NetMessage.SendTileSquare(-1, left + 1, top + 1, 3);
            TripWire(left, top);
            if (Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = mod.GetPacket(256);
                packet.Write(1);
                packet.Write((short)left);
                packet.Write((short)top);
                packet.Send();
            }
        }

        public static void TripWire(int i, int j)
        {
            Main.PlaySound(SoundID.Mech, i * 16 + 16, j * 16 + 16, 0);
            Wiring.TripWire(i, j, 3, 3);
        }
        
		public static int SelectGem(short frameX)
		{
			Mod mod = ModLoader.GetMod("TheDepths");
			int gem = 0;
			switch (frameX / 54)
			{
				case 0:
					gem = mod.ItemType("LargeOnyx");
					break;
			}
			return gem;
		}
    }
}
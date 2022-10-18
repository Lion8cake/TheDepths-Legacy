using System;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using Terraria.Graphics;
using Terraria.Localization;
using Terraria.GameContent.UI.Elements;

namespace TheDepths.Hooks
{
    public class DepthsWorldCreationUI
    {
        private static bool finishedMenus;
        private static bool runBeforeMenus;
        private static bool skipMenus;
        private static int count;
        private static bool isFirst;
        private static readonly bool replacingEvilMenu = false;
        public static void ILDrawMenu(ILContext il)
        {
            var c = new ILCursor(il);

            // Move il cursor into positon
            if (!c.TryGotoNext(i => i.MatchLdloc(47)))
                return;
            if (!c.TryGotoPrev(i => i.MatchLdcI4(-71)))
                return;
            if (!c.TryGotoNext(i => i.MatchBneUn(out _)))
                return;
            c.Index++;

            // Reset variables and go to menumode that we've centred our logic around
            c.EmitDelegate<Action>(() => {
                finishedMenus = false;
                runBeforeMenus = true;
                isFirst = false;
                count = 0;
                skipMenus = false;
                if (replacingEvilMenu)
                {
                    Main.menuMode = 7;
                }
            });

            ILLabel nextMenu = c.DefineLabel();

            // Skip all vanilla evil menu logic
            if (replacingEvilMenu)
            {
                if (!(c.Instrs[c.Index].MatchLdcI4(out _) &&
                    c.Instrs[c.Index + 1].MatchCall(out _) &&
                    c.Instrs[c.Index + 2].MatchCallvirt(out _) &&
                    c.Instrs[c.Index + 3].MatchBr(out _)))
                {
                    c.Emit(OpCodes.Br, nextMenu);
                }
            }

            if (!c.TryGotoNext(i => i.MatchCall(typeof(Main).GetMethod(nameof(Main.clrInput)))))
                return;
            c.MarkLabel(nextMenu);

            if (!c.TryGotoNext(i => i.MatchLdcI4(7)))
                return;
            if (!c.TryGotoNext(i => i.MatchBneUn(out _)))
                return;

            if (!c.TryGotoNext(i => i.MatchLdsfld(out _)))
                return;

            ILLabel skipMenu = c.DefineLabel();

            // Check for another delegate and unique nop placed before to signify another mods ui to work around
            if (c.Instrs[c.Index - 2].MatchCallvirt(out _) && c.Instrs[c.Index - 3].MatchCall(out _) && c.Instrs[c.Index - 4].MatchLdcI4(out _) && c.Instrs[c.Index - 5].MatchNop())
            {
                if (!c.TryGotoPrev(i => i.MatchLdcI4(out _)))
                    return;
                // Allows control over if the previous menu should be skipped or not
                c.EmitDelegate<Func<bool>>(() =>
                {
                    return runBeforeMenus;
                });
                c.Emit(OpCodes.Brfalse, skipMenu);

                if (!c.TryGotoNext(i => i.MatchLdsfld(out _)))
                    return;
            }

            // Main menu logic
            c.MarkLabel(skipMenu);
            c.Emit(OpCodes.Nop);
            c.EmitDelegate<Func<bool>>(() => {
                runBeforeMenus = false;
                // Determines if this is the first menu element by if it hasn't been skipped by any other ui before running
                if (count == 0)
                {
                    isFirst = true;
                }

                // Used to move logic to the next menu ui so that it can lock this method out of operation
                if (skipMenus)
                {
                    skipMenus = false;
                    return true;
                }

                if (!finishedMenus)
                {
                    // First menu to run
                    DepthsMenu();
                    return false;
                }
                else
                {
                    // Last menu if mod menu ahead decides go back from their position ahead and call this method
                    finishedMenus = false;
                    DepthsMenu();
                    return false;
                }
            });

            ILLabel skip = c.DefineLabel();
            // Skip to end of sequence if returning false 
            c.Emit(OpCodes.Brfalse, skip);
            if (!c.TryGotoNext(i => i.MatchLdcI4(888)))
                return;
            c.MarkLabel(skip);
            c.Index++;
            // Incrementing count every time a ui menu has been called
            c.EmitDelegate<Action>(() =>
            {
                count++;
            });
        }
        private static void DepthsMenu()
        {
            UIList optionsList = new UIList();
            optionsList.Add(new UI.ListItem("Depths", TheDepths.mod.GetTexture("Sprites/DepthsTreeIcon"), delegate {
                TheDepthsWorldGen.underworldMenuSelection = TheDepthsWorldGen.UnderworldVariant.depths;
                FinishedMenu();
            }));
            optionsList.Add(new UI.ListItem("Underworld", TheDepths.mod.GetTexture("Sprites/HellTreeIcon"), delegate {
                TheDepthsWorldGen.underworldMenuSelection = TheDepthsWorldGen.UnderworldVariant.underworld;
                FinishedMenu();
            }));
            optionsList.Add(new UI.ListItem("Random", TheDepths.mod.GetTexture("Sprites/BothTrees"), delegate {
                TheDepthsWorldGen.underworldMenuSelection = TheDepthsWorldGen.UnderworldVariant.random;
                FinishedMenu();
            }));;
            Main.MenuUI.SetState(new UI.GenericSelectionMenu("Pick Underworld Type", optionsList, delegate {
                if (isFirst)
                {
                    Main.menuMode = -7;
                }
                else
                {
                    runBeforeMenus = true;
                    Main.menuMode = 7;
                }
            }));
        }
        private static void FinishedMenu()
        {
            skipMenus = true;
            finishedMenus = true;
            Main.menuMode = 7;
        }
    }
}
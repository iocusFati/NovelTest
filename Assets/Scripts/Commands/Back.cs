using System;
using Naninovel;
using Naninovel.Commands;
using Naninovel.UI;
using UI;
using UnityEngine;

namespace Commands
{
    [CommandAlias("back")]
    public class Back : ModifyBackground
    {
        private int _counter;

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            IUIManager uiManager = Engine.GetService<IUIManager>();
            HUD hud = uiManager.GetUI<HUD>();

            if (!showHUD.HasValue || (showHUD.HasValue && showHUD.Value)) 
                ShowHUD(hud);

            return base.ExecuteAsync(asyncToken);
        }

        private static void ShowHUD(HUD hud)
        {
            hud.Appear(true);
            hud.BlockMap(true);
        }
    }
}
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
            
            hud.Appear();
            hud.BlockMap(true);

            return base.ExecuteAsync(asyncToken);
        }
    }
}
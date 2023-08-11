using Naninovel;
using UI;

namespace Commands
{
    public class HideHUD : Command
    {
        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            IUIManager uiManager = Engine.GetService<IUIManager>();
            HUD hud = uiManager.GetUI<HUD>();
            
            hud.Appear(false);
            
            return UniTask.CompletedTask;
        }
    }
}
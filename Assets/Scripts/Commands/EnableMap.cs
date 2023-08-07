using Naninovel;
using UI;

namespace Commands
{
    public class EnableMap : Command
    {
        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            IUIManager uiManager = Engine.GetService<IUIManager>();
            HUD hud = uiManager.GetUI<HUD>();
            
            hud.BlockMap(false);
            
            return UniTask.CompletedTask;
        }
    }
}
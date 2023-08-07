using Naninovel;
using UI;

namespace Commands
{
    public class OpenDungeon : Command
    {
        [RequiredParameter, ParameterAlias(NamelessParameterAlias)]
        public BooleanParameter Open;

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            IUIManager uiManager = Engine.GetService<IUIManager>();
            HUD hud = uiManager.GetUI<HUD>();

            hud.OpenDungeon(Open.Value);

            return UniTask.CompletedTask;
        }
    }
}
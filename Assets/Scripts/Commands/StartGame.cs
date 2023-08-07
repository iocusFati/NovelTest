using Naninovel;
using UI.Services;

namespace Commands
{
    public class StartGame : Command
    {
        public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            MiniGameManager miniGameManager = Engine.GetService<MiniGameManager>();

            await miniGameManager.StartMiniGame();
        }
    }
}
using Naninovel;
using UI.Services;

namespace Commands
{
    public class StartGame : Command
    {
        private const string CardGameBackgroundSoundName = "CardGameBackground";

        public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            MiniGameManager miniGameManager = Engine.GetService<MiniGameManager>();
            
            TurnOnGameBackgroundTheme();

            await miniGameManager.StartMiniGame();
        }

        private static void TurnOnGameBackgroundTheme()
        {
            IAudioManager audioManager = Engine.GetService<IAudioManager>();
            
            audioManager.StopAllBgmAsync();
            audioManager.PlayBgmAsync(CardGameBackgroundSoundName, 0.3f);
        }
    }
}
using System;
using System.Threading.Tasks;
using Gameplay.MiniGameFolder;
using Naninovel;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UI.Services
{
    [InitializeAtRuntime]
    public class MiniGameManager : IEngineService
    {
        private const string MinigamePath = "Prefabs/MiniGame/MiniGame";
        private readonly MiniGameConfig Config;
        private readonly IResourceProviderManager _providersManager;
        
        private ResourceLoader<GameObject> _itemLoader;
        private MiniGame _game;

        public MiniGameManager(MiniGameConfig config, IResourceProviderManager providersManager)
        {
            Config = config;
            _providersManager = providersManager;
        }

        public UniTask InitializeServiceAsync()
        {
            return UniTask.CompletedTask;
        }

        public void ResetService()
        {
        }

        public void DestroyService()
        {
        }

        public async Task StartMiniGame()
        {
            MiniGame gameLoad = await GetGameAsync();
            _game = Object.Instantiate(gameLoad);
            
            _game.GameManager.StartGame(Config.GameSettings);

            await UniTask.WaitUntil(() => !_game.GameManager.IsGameActive);
            
            FinishTheGame();
        }

        private async UniTask<MiniGame> GetGameAsync () => 
            (MiniGame)await Resources.LoadAsync<MiniGame>(MinigamePath);

        private void FinishTheGame()
        {
            _game.gameObject.SetActive(false);
        }
    }
}
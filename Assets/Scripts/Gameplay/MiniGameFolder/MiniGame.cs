using DTT.MinigameMemory;
using DTT.MinigameMemory.Demo;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.MiniGameFolder
{
    public class MiniGame : MonoBehaviour
    {
        [SerializeField] private MemoryGameManager _gameManager;

        public MemoryGameManager GameManager => _gameManager;
    }
}
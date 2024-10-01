using UnityEngine;
using Cysharp.Threading.Tasks;
using LootLocker.Requests;
using Source.Gameplay.Systems;
using Source.Gameplay.Coins;
using Source.Gameplay.Trampoline;
using Zenject;

namespace Source.Gameplay
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private CoinSFX _coinSFX;
        [SerializeField] private TrampolineSFX _trampolineSFX;
        [SerializeField] private LeaderBoardType _leaderBoardType;

        private GameplayStateObserver _gameplayStateObserver;
        private CoinCollisionTrigger[] _coins;
        private TrampolineTrigger[] _tramploneTrigger;

        [Inject]
        private void Construct(GameplayStateObserver gameplayStateObserver)
        {
            _gameplayStateObserver = gameplayStateObserver;
            _gameplayStateObserver.SetLeaderBoardType(_leaderBoardType);
        }

        private void Awake()
        {
            InitCoins();
            InitTrampolines();

            _gameplayStateObserver.SetNumberOfCoins(_coins.Length);
        }

        private void InitCoins()
        {
            _coins = FindObjectsOfType<CoinCollisionTrigger>();

            foreach(CoinCollisionTrigger coin in _coins) coin.Init(_gameplayStateObserver, _coinSFX);
        }

        private void InitTrampolines()
        {
            _tramploneTrigger = FindObjectsOfType<TrampolineTrigger>();

            foreach(TrampolineTrigger trampoline in _tramploneTrigger) trampoline.Init(_trampolineSFX);
        }
    }
}
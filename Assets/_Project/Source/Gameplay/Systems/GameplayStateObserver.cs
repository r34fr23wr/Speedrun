using UnityEngine;
using Cysharp.Threading.Tasks;
using LootLocker.Requests;
using Source.Services.Score;
using Source.Services;
using Source.Services.Timer;
using Source.Gameplay.Common;
using System;
using Zenject;

namespace Source.Gameplay.Systems
{
    public class GameplayStateObserver : IInitializable, IDisposable
    {
        private const Scene _mainMenuScene = Scene.MainMenu;

        private readonly IScoreService _scoreService;
        private readonly ITimerService _timerService;
        private readonly Trashcan _trashcan;
        private readonly SceneLoader _sceneLoader;

        private int _numberOfCoins;
        private LeaderBoardType _leaderBoardType;

        [Inject]
        public GameplayStateObserver(ITimerService timerService, IScoreService scoreService, Trashcan trashcan, SceneLoader sceneLoader)
        {
            _scoreService = scoreService;
            _timerService = timerService;
            _trashcan = trashcan;
            _sceneLoader = sceneLoader;
        }

        public void Initialize()
        {
            _trashcan.FinishGame += OnFinishGame;
        }

        public void Dispose()
        {
            _trashcan.FinishGame -= OnFinishGame;
        }

        public void SetLeaderBoardType(LeaderBoardType leaderBoardType) => _leaderBoardType = leaderBoardType;

        public void SetNumberOfCoins(int amount)
        {
            _numberOfCoins = amount;
        }

        public void OnCoinTrigger()
        {
            _numberOfCoins -= 1;

            if(_numberOfCoins <= 0) OnTriggeredEnoughCoins();
        }

        public void OnStartGame()
        {
            _timerService.StartTimer();
        }

        private void OnTriggeredEnoughCoins()
        {
            _trashcan.Open();
        }

        public void OnFinishGame()
        {
            _timerService.StopTimer();

            _scoreService.SumbitScore(_timerService.CurrentTime, _leaderBoardType);

            _sceneLoader.LoadScene(_mainMenuScene);
        }
    }
}
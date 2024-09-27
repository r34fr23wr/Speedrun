using UnityEngine;
using Zenject;
using System;
using Source.Services.SaveLoad;
using Source.Services.Player;
using LootLocker.Requests;

namespace Source.Services.Score
{
    public class ScoreService : IScoreService
    {
        private readonly ISaveLoadService _saveLoadService;
        private readonly IPlayerService _playerService;

        private float _currentScore;

        public float CurrentScore
        {
            get => _currentScore;
            set
            {
                if(value < 0) throw new ArgumentOutOfRangeException();

                _currentScore = value;

                Save();
            }
        }

        [Inject]
        public ScoreService(ISaveLoadService saveLoadService, IPlayerService playerService)
        {
            _saveLoadService = saveLoadService;
            _playerService = playerService;
        }

        public void SumbitScore(float scoreToUpload)
        {
            CurrentScore = scoreToUpload;
            string playerID = _playerService.CurrentPlayerId;

            LootLockerSDKManager.SubmitScore(playerID, (int)CurrentScore, Consts.LEADER_BOARD_KEY, (response) =>
            {
                if(!response.success)
                {
                    Debug.Log("Could not submit score!");
                    Debug.Log(response.errorData.ToString());

                    return;
                }
  
                Debug.Log("Successfully uploaded score");
            });
        }

        public void Save()
        {
            ScoreData data = new ScoreData(_currentScore);
            _saveLoadService.Save(data);
        }

        public void Load()
        {
            ScoreData data = _saveLoadService.LoadScoreData();
            _currentScore = data != null ? data.Score : 0;
        }
    }
}
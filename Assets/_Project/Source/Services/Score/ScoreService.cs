using UnityEngine;
using Zenject;
using System;
using Source.Services.SaveLoad;

namespace Source.Services.Score
{
    public class ScoreService : IScoreService
    {
        private readonly ISaveLoadService _saveLoadService;

        private int _currentScore;

        public int CurrentScore
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
        public ScoreService(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        public void AddScore(int amount)
        {
            CurrentScore += amount;
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
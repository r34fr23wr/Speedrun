using UnityEngine;

namespace Source.Services.Score
{
    public interface IScoreService
    {
        int CurrentScore { get; }
        void AddScore(int amount);
        void Save();
        void Load();
    }
}
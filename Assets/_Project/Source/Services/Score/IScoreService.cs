using UnityEngine;

namespace Source.Services.Score
{
    public interface IScoreService
    {
        float CurrentScore { get; }
        void SumbitScore(float amount, LeaderBoardType leaderBoardType);
        void Save();
        void Load();
    }
}
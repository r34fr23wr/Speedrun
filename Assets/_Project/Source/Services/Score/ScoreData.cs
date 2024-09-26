using UnityEngine;

namespace Source.Services.Score
{
    [System.Serializable]
    public class ScoreData
    {
        public int Score { get; private set; }

        public ScoreData(int score)
        {
            Score = score;
        }
    }
}
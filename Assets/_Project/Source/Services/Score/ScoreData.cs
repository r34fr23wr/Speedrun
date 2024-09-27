using UnityEngine;

namespace Source.Services.Score
{
    [System.Serializable]
    public class ScoreData
    {
        public float Score { get; private set; }

        public ScoreData(float score)
        {
            Score = score;
        }
    }
}
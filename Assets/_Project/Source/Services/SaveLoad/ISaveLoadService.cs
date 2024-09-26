using UnityEngine;
using Source.Services.Score;
using Source.Services.Player;

namespace Source.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        void Save(ScoreData data);

        ScoreData LoadScoreData();

        void Save(PlayerData data);

        PlayerData LoadPlayerData();
    }
}
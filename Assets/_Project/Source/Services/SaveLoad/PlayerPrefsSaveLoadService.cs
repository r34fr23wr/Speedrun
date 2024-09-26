using UnityEngine;
using Source.Services.Score;
using Source.Services.Player;
using System;

namespace Source.Services.SaveLoad
{
    public class PlayerPrefsSaveLoadService : ISaveLoadService
    {
        private const string ScoreKey = "player_score";
        private const string PlayerKey = "player_key";

        public void Save(ScoreData data)
        {
            string jsonData = JsonUtility.ToJson(data);

            PlayerPrefs.SetString(ScoreKey, jsonData);
            PlayerPrefs.Save();
        }

        public ScoreData LoadScoreData()
        {
            if(PlayerPrefs.HasKey(ScoreKey))
            {
                string jsonData = PlayerPrefs.GetString(ScoreKey);

                return JsonUtility.FromJson<ScoreData>(jsonData);
            }

            return new ScoreData(0);
        }

        public void Save(PlayerData data)
        {
            string jsonData = JsonUtility.ToJson(data);

            PlayerPrefs.SetString(PlayerKey, jsonData);
            PlayerPrefs.Save();
        }

        public PlayerData LoadPlayerData()
        {
            if(PlayerPrefs.HasKey(PlayerKey))
            {
                string jsonData = PlayerPrefs.GetString(PlayerKey);

                return JsonUtility.FromJson<PlayerData>(jsonData);
            }

            return new PlayerData(null);
        }
    }
}
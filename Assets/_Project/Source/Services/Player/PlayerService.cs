using UnityEngine;
using Zenject;
using System;
using Source.Services.SaveLoad;

namespace Source.Services.Player
{
    public class PlayerService : IPlayerService
    {
        private readonly ISaveLoadService _saveLoadService;

        private string _currentPlayerId;

        public string CurrentPlayerId
        {
            get => _currentPlayerId;
            set
            {
                _currentPlayerId = value;

                Save();
            }
        }

        [Inject]
        public PlayerService(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        public void SetPlayerId(string playerId)
        {
            CurrentPlayerId = playerId;
        }

        public void Save()
        {
            PlayerData data = new PlayerData(_currentPlayerId);
            _saveLoadService.Save(data);
        }

        public void Load()
        {
            PlayerData data = _saveLoadService.LoadPlayerData();
            _currentPlayerId = data != null ? data.PlayerId : null;
        }
    }
}
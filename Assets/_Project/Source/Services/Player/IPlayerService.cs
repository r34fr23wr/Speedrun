using UnityEngine;

namespace Source.Services.Player
{
    public interface IPlayerService
    {
        string CurrentPlayerId { get; }
        void SetPlayerId(string playerId);
        void Save();
        void Load();
    }
}
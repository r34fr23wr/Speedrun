using UnityEngine;

namespace Source.Services.Player
{
    [System.Serializable]
    public class PlayerData
    {
        public string PlayerId { get; private set; }

        public PlayerData(string playerId)
        {
            PlayerId = playerId;
        }
    }
}
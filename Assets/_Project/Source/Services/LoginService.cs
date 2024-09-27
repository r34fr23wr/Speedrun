using UnityEngine;
using Cysharp.Threading.Tasks;
using LootLocker.Requests;
using Source.Services.Player;

namespace Source.Services
{
    public class LoginService
    {
        private readonly IPlayerService _playerService;

        public LoginService(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async UniTask Login(string playerName)
        {
            bool done = false;

            LootLockerSDKManager.StartGuestSession((response) =>
            {
                if(!response.success)
                {
                    Debug.Log("Could not start session");
                    return;
                }
  
                Debug.Log("Player was logged in");

                //_playerService.SetPlayerId(response.player_id.ToString());
                _playerService.SetPlayerId(playerName);
                done = true;
            });

            await UniTask.WaitUntil(() => done);
        }
    }
}
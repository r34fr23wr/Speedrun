using UnityEngine;
using Cysharp.Threading.Tasks;
using LootLocker.Requests;
using Zenject;
using Source.Services.Player;
using Source.Services;

namespace Source.Boot
{
    public class BootService : IInitializable
    {
        private const Scene FirstSceneToLoad = Scene.MainMenu;

        private readonly SceneLoader _sceneLoader;
        private readonly IPlayerService _playerService;

        public BootService(SceneLoader sceneLoader, IPlayerService playerService)
        {
            _sceneLoader = sceneLoader;
            _playerService = playerService;
        }

        public async void Initialize()
        {
            await Login();
            await _sceneLoader.LoadScene(FirstSceneToLoad);
        }

        private async UniTask Login()
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

                _playerService.SetPlayerId(response.player_id.ToString());
                done = true;
            });

            await UniTask.WaitUntil(() => done);
        }
    }
}

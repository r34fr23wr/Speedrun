using UnityEngine;
using Cysharp.Threading.Tasks;
using LootLocker.Requests;
using Source.Services.Player;
using Source.Services;
using Zenject;
using TMPro;

namespace Source.Loading
{
    public class LoadingEntryPoint : MonoBehaviour
    { 
        private const Scene SecondSceneToLoad = Scene.MainMenu;

        [SerializeField] private TextMeshProUGUI _inputPlayerNameText;

        private SceneLoader _sceneLoader;
        private LoginService _loginService;

        [Inject]
        private void Construct(SceneLoader sceneLoader, LoginService loginService)
        {
            _sceneLoader = sceneLoader;
            _loginService = loginService;
        }

        public async void LoadMainMenuScene()
        {
            await _loginService.Login(_inputPlayerNameText.text);
            await _sceneLoader.LoadScene(SecondSceneToLoad);
        }
    }
}
using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;
using Source.Services.Player;
using Source.Services;

namespace Source.Boot
{
    public class BootService : IInitializable
    {
        private const Scene FirstSceneToLoad = Scene.Loading;

        private readonly SceneLoader _sceneLoader;

        public BootService(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public async void Initialize()
        {
            _sceneLoader.LoadScene(FirstSceneToLoad);
        }
    }
}

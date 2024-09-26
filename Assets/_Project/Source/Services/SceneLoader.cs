using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Source.Services
{
    public class SceneLoader
    {
        public event Action StartLoadingScene;
        public event Action EndLoadingScene;

        public async UniTask LoadScene(Scene scene)
        {
            StartLoadingScene?.Invoke();

            string sceneName = scene.ToString();

            AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            await loadSceneOperation.ToUniTask();

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

            EndLoadingScene?.Invoke();
        }
    }
}
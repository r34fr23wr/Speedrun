using UnityEngine;
using Zenject;
using UnityEngine.UI;
using Source.Services;

namespace Source.UI
{
    [RequireComponent(typeof(Button))]
    public class LoadSceneButton : MonoBehaviour
    {
        [SerializeField] private Scene _scene;

        [Inject]
        private void Construct(SceneLoader sceneLoader) =>
            GetComponent<Button>().onClick.AddListener(() =>
            {   
                sceneLoader.LoadScene(_scene);
            });
    }
}
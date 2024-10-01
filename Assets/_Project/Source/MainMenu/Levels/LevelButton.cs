using UnityEngine;
using Zenject;
using UnityEngine.UI;
using Source.Services;

namespace Source.MainMenu.Levels
{
    [RequireComponent(typeof(Button))]
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private Scene _scene;
        [SerializeField] private LeaderBoardType _leaderBoardType;

        public LeaderBoardType LeaderBoardType => _leaderBoardType;

        private SceneLoader _sceneLoader;
        private LevelButtonVFX _vfx;

        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _vfx = new LevelButtonVFX(transform);
        }

        public void OnSelect() => _vfx.Select();

        public void OnUnSelect() => _vfx.UnSelect();

        public void OnPress() => _sceneLoader.LoadScene(_scene);
    }
}
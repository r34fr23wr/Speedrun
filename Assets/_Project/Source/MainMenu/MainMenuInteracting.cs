using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using Zenject;
using Source.MainMenu.Levels;

namespace Source.MainMenu
{
    public class MainMenuInteracting : MonoBehaviour
    {
        [SerializeField] private LeaderBoardView _leaderBoardView;
        [SerializeField] private List<LevelButton> _levelButtons;

        private int _currentLevelButton = 0;

        private PlayerInputInMenu _playerInputInMenu;

        [Inject]
        private void Construct(PlayerInputInMenu playerInputInMenu)
        {
            _playerInputInMenu = playerInputInMenu;
        }

        private void Start()
        {
            SelectButton();
            _leaderBoardView.FetchTopHighscoresRoutine(_levelButtons[_currentLevelButton].LeaderBoardType);

        }

        private void OnEnable()
        {
            _playerInputInMenu.Enable();

            _playerInputInMenu.Interact.SwipeLeft.performed += OnSwipeLeft;
            _playerInputInMenu.Interact.SwipeRight.performed += OnSwipeRight;
            _playerInputInMenu.Interact.PressButton.performed += OnPressButton;
        }

        private void OnDestroy()
        {
            _playerInputInMenu.Disable();

            _playerInputInMenu.Interact.SwipeLeft.performed -= OnSwipeLeft;
            _playerInputInMenu.Interact.SwipeRight.performed -= OnSwipeRight;
            _playerInputInMenu.Interact.PressButton.performed -= OnPressButton;
        }

        private void OnSwipeLeft(InputAction.CallbackContext context)
        {
            if(_currentLevelButton <= 0) return;

            _currentLevelButton--;
            SelectButton();
            _leaderBoardView.FetchTopHighscoresRoutine(_levelButtons[_currentLevelButton].LeaderBoardType);
        }

        private void OnSwipeRight(InputAction.CallbackContext context)
        {
            if(_currentLevelButton  >= _levelButtons.Count - 1) return;

            _currentLevelButton++;
            SelectButton();
            _leaderBoardView.FetchTopHighscoresRoutine(_levelButtons[_currentLevelButton].LeaderBoardType);
        }

        private void OnPressButton(InputAction.CallbackContext context)
        {
            _levelButtons[_currentLevelButton].OnPress();
        }

        private void SelectButton()
        {
            foreach(LevelButton levelButton in _levelButtons) levelButton.OnUnSelect();

            _levelButtons[_currentLevelButton].OnSelect();
        }
    }
}
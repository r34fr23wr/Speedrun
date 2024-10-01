using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Source.Services
{
    public class GameReloadService : IDisposable
    {
        private readonly CharacterInput _characterInput;

        public GameReloadService(CharacterInput characterInput)
        {
            _characterInput = characterInput;

            _characterInput.SceneReloading.Reload.performed += OnReloadScene;
        }

        public void Dispose()
        {
            _characterInput.SceneReloading.Reload.performed -= OnReloadScene;
        }

        public void OnReloadScene(InputAction.CallbackContext context)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
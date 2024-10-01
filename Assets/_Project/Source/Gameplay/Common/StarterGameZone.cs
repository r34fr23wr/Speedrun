using UnityEngine;
using Source.Gameplay.Character;
using Source.Gameplay.Systems;
using Zenject;

namespace Source.Gameplay.Common
{
    public class StarterGameZone : MonoBehaviour
    {
        private GameplayStateObserver _gameplayStateObserver;

        [Inject]
        private void Construct(GameplayStateObserver gameplayStateObserver)
        {
            _gameplayStateObserver = gameplayStateObserver;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.gameObject.GetComponent<Character.Character>())
            {
                _gameplayStateObserver.OnStartGame();
                Destroy(gameObject);
            }
        }
    }
}
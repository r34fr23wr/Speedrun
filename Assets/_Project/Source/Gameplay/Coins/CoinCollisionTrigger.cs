using UnityEngine;
using Source.Gameplay.Character;
using Source.Gameplay.Systems;

namespace Source.Gameplay.Coins
{
    public class CoinCollisionTrigger : MonoBehaviour
    {
        private CoinSFX _coinSFX;
        private GameplayStateObserver _gameplayStateObserver;

        public void Init(GameplayStateObserver gameplayStateObserver, CoinSFX coinSFX)
        {
            _gameplayStateObserver = gameplayStateObserver;
            _coinSFX = coinSFX;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.GetComponent<Character.Character>())
            {
                _gameplayStateObserver.OnCoinTrigger();
                _coinSFX.PlayTakeCoinSound();

                gameObject.SetActive(false);
            }
        }
    }
}
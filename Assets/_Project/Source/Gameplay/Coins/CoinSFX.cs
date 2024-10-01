using UnityEngine;

namespace Source.Gameplay.Coins
{
    public class CoinSFX : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [Space]

        [SerializeField] private AudioClip _takeCoinClip;

        private void OnValidate() => _audioSource ??= GetComponent<AudioSource>();

        public void PlayTakeCoinSound() => _audioSource.PlayOneShot(_takeCoinClip);
    }
}
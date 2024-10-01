using UnityEngine;
using Zenject;

namespace Source.Gameplay.Character
{
    public class CharacterSFX : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private CharacterMovement _movement;
        [Space]

        [SerializeField] private AudioClip _jumpClip, _landClip;

        private void OnValidate() => _audioSource ??= GetComponent<AudioSource>();


        private void OnEnable()
        {
            _movement.Jumped += PlayJumpedSound;
            _movement.Landed += PlayLandedSound;
        }

        private void OnDisable()
        {
            _movement.Jumped -= PlayJumpedSound;
            _movement.Landed -= PlayLandedSound;
        }

        private void PlayJumpedSound() => _audioSource.PlayOneShot(_jumpClip);

        private void PlayLandedSound() => _audioSource.PlayOneShot(_landClip);

    }
}
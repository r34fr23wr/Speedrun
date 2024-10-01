using UnityEngine;

namespace Source.Gameplay.Trampoline
{
    public class TrampolineSFX : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [Space]

        [SerializeField] private AudioClip _tramploneTrigger;

        private void OnValidate() => _audioSource ??= GetComponent<AudioSource>();

        public void PlayTriggerSound() => _audioSource.PlayOneShot(_tramploneTrigger);
    }
}
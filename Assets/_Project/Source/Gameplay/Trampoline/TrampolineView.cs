using UnityEngine;
using Source.Gameplay.Character;
using Source.Gameplay.Systems;
using Zenject;

namespace Source.Gameplay.Trampoline
{
    public class TrampolineView : MonoBehaviour
    {
        private const string _triggerKey = "trigger";

        [SerializeField] private Animator _animator;

        private void OnValidate()
        {
            _animator ??= GetComponent<Animator>();
        }

        public void OnTrigger() => _animator.SetTrigger(_triggerKey);
    }
}
using UnityEngine;
using Zenject;

namespace Source.Gameplay.Character
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;

        [Space]
        [SerializeField] private CharacterData _data;

        private CharacterInput _input;

        [Inject]
        private void Construct(CharacterInput input)
        {
            _input = input;
        }

        private void OnValidate()
        {
            _movement ??= GetComponent<CharacterMovement>();
        }

        private void Start()
        {
            _movement.Init(_data, _input);
        }

        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }
    }
}
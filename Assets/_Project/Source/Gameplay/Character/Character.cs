using UnityEngine;
using Zenject;

namespace Source.Gameplay.Character
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;
        [SerializeField] private GravityHandler _gravityHandler;
        [SerializeField] private CharacterView _view;

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
            _gravityHandler ??= GetComponent<GravityHandler>();
            _view ??= GetComponentInChildren<CharacterView>();
        }

        private void Start()
        {
            _movement.Init(_data, _input);
            _gravityHandler.Init(_data);
            _view.Init(_movement, _gravityHandler);
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
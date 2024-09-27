using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Gameplay.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private Transform _feetPoint;
        [SerializeField] private LayerMask _groundLayer;

        private float _speed;
        private float _jumpForce;
        private float _checkGroundRadius;

        private float _moveInputX;

        private CharacterData _data;
        private Rigidbody2D _rigidbody2D;
        private CharacterInput _input;

        public void Init(CharacterData data, CharacterInput input)
        {
            _data = data;
            _input = input;

            _speed = _data.Speed;
            _jumpForce = _data.JumpForce;
            _checkGroundRadius = _data.CheckGroundRadius;

            _rigidbody2D = GetComponent<Rigidbody2D>(); 

            _input.Movement.Jump.performed += Jump;
        }

        private void OnDestroy()
        {
            _input.Movement.Jump.performed -= Jump;
        }

        private void Update()
        {
            _moveInputX = ReadMoveInput().x;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move() => _rigidbody2D.velocity = new Vector2(_moveInputX * _speed, _rigidbody2D.velocity.y);

        private void Jump(InputAction.CallbackContext context)
        {
            if(!IsGround()) return;
            
            _rigidbody2D.velocity = Vector2.up * _jumpForce; 
        }

        private Vector2 ReadMoveInput() => _input.Movement.Move.ReadValue<Vector2>();

        private bool IsGround() => Physics2D.OverlapCircle(_feetPoint.position, _checkGroundRadius, _groundLayer);
    }
}
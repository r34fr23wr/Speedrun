using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace Source.Gameplay.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        public event Action<float> MoveComputed;

        public event Action Jumped;
        public event Action Landed;

        [SerializeField] private Transform _feetPoint;
        [SerializeField] private LayerMask _groundLayer;

        private float _speed;
        private float _jumpForce;
        private float _checkGroundRadius;

        private float _moveInputX;
        private bool _canLanded;

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
            MoveComputed?.Invoke(_moveInputX);

            if(IsGround() && _canLanded)
            {
                Landed?.Invoke();

                _canLanded = false;
            }

            if(!IsGround()) _canLanded = true;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move() => _rigidbody2D.velocity = new Vector2(_moveInputX * _speed, _rigidbody2D.velocity.y);

        private void Jump(InputAction.CallbackContext context)
        {
            if(!IsGround()) return;

            Jumped?.Invoke();
            
            _rigidbody2D.velocity = Vector2.up * _jumpForce;
        }

        private Vector2 ReadMoveInput() => _input.Movement.Move.ReadValue<Vector2>();

        private bool IsGround() => Physics2D.OverlapCircle(_feetPoint.position, _checkGroundRadius, _groundLayer);

        private void OnDrawGizmosSelected()
        {
            if(_feetPoint == null) return;
 
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_feetPoint.position, _checkGroundRadius);
        }
    }
}
using UnityEngine;
using Zenject;

namespace Source.Gameplay.Character
{
    public class CharacterView : MonoBehaviour
    {
        private const string _isMovingKey = "isMoving";
        private const string _jumpingKey = "jumping";
        private const string _landingKey = "landing";
        private const string _landedKey = "landed";

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Animator _animator;

        private CharacterMovement _movement;
        private GravityHandler _gravityHandler;
        private bool _isJumping;

        private void OnValidate()
        {
            _spriteRenderer ??= GetComponent<SpriteRenderer>();
            _animator ??= GetComponent<Animator>();
        }

        public void Init(CharacterMovement movevement, GravityHandler gravityHandler)
        {
            _movement = movevement;
            _gravityHandler = gravityHandler;

            _movement.MoveComputed += SetMoveAnimation;
            _movement.MoveComputed += Flip;
            _movement.Jumped += SetJumpState;
            _movement.Landed += SetLandState;

            _gravityHandler.GravityComputed += SetJumpingAnimation;
        }

        private void OnDestroy()
        {
            _movement.MoveComputed -= SetMoveAnimation;
            _movement.MoveComputed -= Flip;
            _movement.Jumped -= SetJumpState;
            _movement.Landed -= SetLandState;

            _gravityHandler.GravityComputed -= SetJumpingAnimation;
        }

        private void SetMoveAnimation(float moveDirection)
        {
            if(moveDirection == 0) _animator.SetBool(_isMovingKey, false);
            else _animator.SetBool(_isMovingKey, true);
        }

        private void SetJumpState() => _isJumping = true;

        private void SetJumpingAnimation(float gravityVelocity)
        {
            if(!_isJumping) return;

            if(gravityVelocity > 0) _animator.SetTrigger(_jumpingKey);
            else if(gravityVelocity < 0) _animator.SetTrigger(_landingKey);
        }

        private void SetLandState()
        {
            _isJumping = false;
            _animator.SetTrigger(_landedKey);
        }


        private void Flip(float moveDirection)
        {
            if(moveDirection < 0) _spriteRenderer.flipX = true;
            else if(moveDirection > 0) _spriteRenderer.flipX = false;
        }
    }
}
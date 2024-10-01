using UnityEngine;
using System;
using Zenject;

namespace Source.Gameplay.Character
{
    public class GravityHandler : MonoBehaviour
    {
        public event Action<float> GravityComputed;

        private float _fallSpeedMultiplier;
        private float _lowJumpSpeedMultiplier;
    
        private Rigidbody2D _rigidbody2D;

        public void Init(CharacterData data)
        {
            _fallSpeedMultiplier = data.FallSpeedMultiplier;
            _lowJumpSpeedMultiplier = data.LowJumpSpeedMultiplier;

            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            GravityComputed?.Invoke(_rigidbody2D.velocity.y);

            if(_rigidbody2D.velocity.y < 0)
                _rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (_fallSpeedMultiplier - 1) * Time.deltaTime;
            else if(_rigidbody2D.velocity.y > 0)
               _rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (_lowJumpSpeedMultiplier - 1) * Time.deltaTime;
        }

        public void SetGravityVelcoityUp(float force) => _rigidbody2D.velocity = Vector2.up * force;
    }
}
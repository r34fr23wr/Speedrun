using UnityEngine;

namespace Source.Gameplay.Character
{
    [CreateAssetMenu(menuName = "Source/Datas/Character", fileName = "CharacterData", order = 0)]
    public class CharacterData : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _checkGroundRadius;
        [SerializeField] private float _jumpForce;

        [Space]
        [SerializeField, Min(0.5f)] private float _fallSpeedMultiplier = 2f;
        [SerializeField, Min(1f)] private float _lowJumpSpeedMultiplier = 2.5f;

        public float Speed => _speed;
        public float CheckGroundRadius => _checkGroundRadius;
        public float JumpForce => _jumpForce;

        public float FallSpeedMultiplier => _fallSpeedMultiplier;
        public float LowJumpSpeedMultiplier => _lowJumpSpeedMultiplier;
    }
}
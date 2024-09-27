using UnityEngine;

namespace Source.Gameplay.Character
{
    [CreateAssetMenu(menuName = "Source/Datas/Character", fileName = "CharacterData", order = 0)]
    public class CharacterData : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _checkGroundRadius;
        [SerializeField] private float _jumpForce;

        public float Speed => _speed;
        public float CheckGroundRadius => _checkGroundRadius;
        public float JumpForce => _jumpForce;
    }
}
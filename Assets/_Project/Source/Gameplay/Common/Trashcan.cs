using UnityEngine;
using Source.Gameplay.Character;
using Source.Gameplay.Systems;
using Zenject;
using System;

namespace Source.Gameplay.Common
{
    public class Trashcan : MonoBehaviour
    {
        public event Action FinishGame;

        [SerializeField] private Animator _animator;

        private bool _isOpen = false;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!_isOpen) return;

            if(other.gameObject.GetComponent<Character.Character>())
            {
                FinishGame?.Invoke();
            }
        }

        public void Open()
        {
            _animator.enabled = true;
            _isOpen = true;
        }
    }
}
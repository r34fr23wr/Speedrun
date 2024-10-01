using UnityEngine;
using Source.Gameplay.Character;
using Source.Gameplay.Systems;
using Zenject;

namespace Source.Gameplay.Trampoline
{
    public class TrampolineTrigger : MonoBehaviour
    {
        [SerializeField] private TrampolineView _view;
        [SerializeField] private float _reboundForce;

        private TrampolineSFX _trampolineSFX;

        private void OnValidate()
        {
            _view ??= GetComponentInChildren<TrampolineView>();
        }

        public void Init(TrampolineSFX trampolineSFX)
        {
            _trampolineSFX = trampolineSFX;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent(out GravityHandler gravityHandler))
            {
                ContactPoint2D contact = collision.GetContact(0);
                Vector2 collisionNormal = contact.normal;

                if(collisionNormal.y < -0.1f)
                {
                    _trampolineSFX.PlayTriggerSound();
                    _view.OnTrigger();
                    gravityHandler.SetGravityVelcoityUp(_reboundForce);
                }
            }
        }
    }
}
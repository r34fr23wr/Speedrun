using UnityEngine;

namespace Source.Gameplay.Platform
{
    public class PlatformMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _checkDistance = 0.1f;

        [Space]
        [SerializeField] private Transform _platform;
        [SerializeField] private Transform _pointA;
        [SerializeField] private Transform _pointB;

        private Vector3 _targetPosition;

        private void Start() => _targetPosition = _pointB.position;

        private void Update()
        {
            Move();

            if(Vector3.Distance(_platform.position, _targetPosition) < _checkDistance)
            {
                if(_targetPosition == _pointA.position) _targetPosition = _pointB.position;
                else _targetPosition = _pointA.position;
            }
        }

        private void Move() => _platform.position = Vector3.MoveTowards(_platform.position, _targetPosition, _speed * Time.deltaTime);
    }
}
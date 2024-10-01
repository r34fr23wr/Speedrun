using DG.Tweening;
using UnityEngine;

namespace Source.MainMenu.Levels
{
    public class LevelButtonVFX
    {
        private const float _scaleDuration = 0.25f;
        private const float _normalScale = 1f;
        private const float _selectedScale = 1.15f;

        private readonly Transform _transform;

        public LevelButtonVFX(Transform transform) => _transform = transform;

        public void Select() => _transform.DOScale(_selectedScale, _scaleDuration).SetEase(Ease.OutBack);

        public void UnSelect() => _transform.DOScale(_normalScale, _scaleDuration).SetEase(Ease.OutBack);
    }
}
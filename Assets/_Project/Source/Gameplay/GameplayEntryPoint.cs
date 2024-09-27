using UnityEngine;
using Cysharp.Threading.Tasks;
using LootLocker.Requests;
using Source.Services.Score;
using Zenject;

namespace Source.Gameplay
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private float _time = 5.64f;

        private float _timeBasedScore => _time * 1000f;

        private IScoreService _scoreService;

        [Inject]
        private void Construct(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        private void Awake()
        {
            _scoreService.SumbitScore(_timeBasedScore);
        }
    }
}
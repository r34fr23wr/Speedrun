using UnityEngine;
using Zenject;
using System.Text;
using TMPro;
using Source.Services.Timer;

namespace Source.UI
{
    public class TimerDisplayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timeDisplayText;

        private ITimerService _timerService;
        private StringBuilder _stringBuilder = new StringBuilder();

        [Inject]
        private void Construct(ITimerService timerService)
        {
            _timerService = timerService;
        }

        private void OnEnable()
        {
            _timerService.TimeChanged += OnTimeChanged;
        }

        private void OnDisable()
        {
            _timerService.TimeChanged -= OnTimeChanged;
        }

        private void OnTimeChanged(float timeToDisplay)
        {
            _stringBuilder.Clear();

            int seconds = Mathf.FloorToInt(timeToDisplay % 60);
            int milliseconds = Mathf.FloorToInt((timeToDisplay * 100) % 100);

            _stringBuilder.Append(string.Format("{0:0}.{1:0}", seconds, milliseconds));

            _timeDisplayText.text = _stringBuilder.ToString();
        }
    }
}
using UnityEngine;
using Zenject;
using System;
using TMPro;

namespace Source.Services.Timer
{
    public class TimerService : ITimerService, ITickable
    {
        public event Action<float> TimeChanged;

        private float _currentTime;
        private bool _isWorking;

        public float CurrentTime
        {
            get => _currentTime;
            set
            {
                if(value < 0) throw new ArgumentOutOfRangeException();

                _currentTime = value;
            }
        }

        public void Tick()
        {
            if(!_isWorking) return;

            ChangeTime();
        }

        public void ChangeTime()
        {
            CurrentTime += Time.deltaTime;

            TimeChanged?.Invoke(CurrentTime);
        }

        public void StartTimer() => _isWorking = true;

        public void StopTimer() => _isWorking = false;
    }
}
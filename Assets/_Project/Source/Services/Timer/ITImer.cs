using UnityEngine;
using System;

namespace Source.Services.Timer
{
    public interface ITimerService
    {
        event Action<float> TimeChanged;
        float CurrentTime { get; }
        void ChangeTime();
        void StartTimer();
        void StopTimer();
    }
}
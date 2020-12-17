using System;
using UnityEngine;


namespace AsteroidsPakAleksey
{
    public sealed class Timer
    {
        private float _limitTime;
        public float TimeStart;
        public bool IsStart { get; set; }
        public event Action StopTimer = delegate {};

        public Timer(float limitTime)
        {
            _limitTime = limitTime;
        }

        public void TimerGo()
        {
            if (IsStart && TimeStart < _limitTime)
            {
                TimeStart += Time.deltaTime;
            }
            else
            {
                IsStart = false;
                TimeStart = 0;
                StopTimer.Invoke();
            }
        }
    }
}

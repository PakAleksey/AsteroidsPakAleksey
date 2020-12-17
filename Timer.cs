using System;
using UnityEngine;


namespace AsteroidsPakAleksey
{
    public sealed class Timer
    {
        private float _limitTime;
        public float TimeStart;
        public event Action StopTimer = delegate {};

        public Timer(float limitTime)
        {
            _limitTime = limitTime;
        }

        public void TimerGo()
        {
            if (TimeStart < _limitTime)
            {
                TimeStart += Time.deltaTime;
            }
            else
            {
                TimeStart = 0;
                StopTimer.Invoke();
            }
        }
    }
}

using System;
using UnityEngine;


namespace AsteroidsPakAleksey
{
    public sealed class Timer
    {
        public float TimeStart;
        public bool IsStart;
        public event Action StopTimer = delegate {};

        public void TimerGo()
        {
            if (IsStart && TimeStart < 10)
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

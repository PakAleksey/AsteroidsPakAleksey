﻿using UnityEngine;
using System;
using System.Collections;


namespace AsteroidsPakAleksey
{
    public sealed class TimerReturnToPool : MonoBehaviour
    {
        public event Action ReturnToPoolBullet = delegate { };
        private const float _limitTime = 2;

        private void Awake()
        {
            StartCoroutine(ReturnToPool());
        }

        private IEnumerator ReturnToPool()
        {
            yield return new WaitForSeconds(_limitTime);
            ReturnToPoolBullet?.Invoke();
        }
    }
}
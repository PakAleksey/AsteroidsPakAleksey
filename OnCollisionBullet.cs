using UnityEngine;
using System;


namespace AsteroidsPakAleksey
{
    public sealed class OnCollisionBullet : MonoBehaviour
    {
        public event Action ReturnToPoolBullet = delegate { };

        private void OnCollisionEnter2D(Collision2D collision)
        {
            ReturnToPoolBullet?.Invoke();
        }
    }
}

using System;
using UnityEngine;

namespace AsteroidsPakAleksey
{
    [Serializable]
    public struct PlayerDataRelevant
    {
        public GameObject PlayerPrefab;
        public float MaxHealth;
        public float CurrentHealth;       
        public float Speed;
        public float Acceleration;        
        public Vector3 Move;
    }
}

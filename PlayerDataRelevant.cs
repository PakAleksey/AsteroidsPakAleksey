using System;
using UnityEngine;

namespace AsteroidsPakAleksey
{
    [Serializable]
    public struct PlayerDataRelevant
    {
        public GameObject PlayerObject;
        public float Health;
        public float Speed;
        public float Acceleration;        
        public Vector3 Move;
    }
}

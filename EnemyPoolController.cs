using UnityEngine;
using System.Collections.Generic;
using AsteroidsPakAleksey.Object_Pool;


namespace AsteroidsPakAleksey
{
    public class EnemyPoolController 
    {
        protected HashSet<EnemyModel> _asteroids;
        protected HashSet<EnemyModel> _comets;

        public EnemyPoolController(HashSet<EnemyModel> asteroids, HashSet<EnemyModel> comets)
        {
            _asteroids = asteroids;
            _comets = comets;
        }           
    }
}

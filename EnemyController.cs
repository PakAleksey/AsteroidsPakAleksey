using UnityEngine;
using System.Collections.Generic;


namespace AsteroidsPakAleksey
{
    public class EnemyController
    {
        //private Dictionary<string, List<EnemyModel>> _enemys;
        public static EnemyControllerFactory EnemyControllerFactory;
        private List<EnemyModel> _asteroids;
        private List<EnemyModel> _comets;

        public EnemyController(List<EnemyModel> asteroids, List<EnemyModel> comets)
        {
            _asteroids = asteroids;
            _comets = comets;
        }

        public void InstantiateEnemy()
        {
            foreach (var enemy in _asteroids)
            {
                GameObject.Instantiate(enemy.EnemyDataRelevant.EnemyPrefab, RandomVector(), new Quaternion());
            }
            foreach (var enemy in _comets)
            {
                GameObject.Instantiate(enemy.EnemyDataRelevant.EnemyPrefab, RandomVector(), new Quaternion());
            }
        }

        private Vector3 RandomVector()
        {
            var vector = new Vector3(Random.Range(1, 20), Random.Range(1, 20), Random.Range(1, 20));
            return vector;
        }
    }
}

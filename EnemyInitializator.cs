using UnityEngine;
using System.Collections.Generic;
using AsteroidsPakAleksey.Object_Pool;


namespace AsteroidsPakAleksey
{
    public sealed class EnemyInitializator
    {
        private List<EnemyModel> _asteroids;
        private List<EnemyModel> _comets;
        private Dictionary<string, List<EnemyModel>> _enemys;
        public EnemyInitializator(GameController gameController, EnemyData asteroid, EnemyData comet)
        {
            _asteroids = new List<EnemyModel>();
            _comets = new List<EnemyModel>();
            _enemys = new Dictionary<string, List<EnemyModel>>();
            for (int i = 0; i < 5; i++)
            {                
                _asteroids.Add(MakeModel(asteroid));
                _comets.Add(MakeModel(comet));                
            }
            _enemys.Add(NameManager.ASTEROID, _asteroids);
            _enemys.Add(NameManager.COMET, _comets);
            gameController.EnemyModelTake(_asteroids, _comets, _enemys);
        }

        private EnemyModel MakeModel(EnemyData enemyData)
        {
            var NewEnemyData = enemyData.enemyDataRelevant;
            var NewEnemyComponents = enemyData.enemyComponents;
            NewEnemyComponents.Rigidbody2D = NewEnemyData.EnemyPrefab.GetComponent<Rigidbody2D>();
            NewEnemyComponents.StartPosition = NewEnemyData.EnemyPrefab.GetComponent<Transform>();
            var NewEnemyModel = new EnemyModel(NewEnemyData, NewEnemyComponents);
            return NewEnemyModel;
        }
    }
}

using UnityEngine;
using System.Collections.Generic;
using AsteroidsPakAleksey.Object_Pool;


namespace AsteroidsPakAleksey
{
    public sealed class EnemyInitializator
    {
        private HashSet<EnemyModel> _asteroids;
        private HashSet<EnemyModel> _comets;

        public EnemyInitializator(GameController gameController, EnemyData asteroid, EnemyData comet)
        {
            _asteroids = new HashSet<EnemyModel>();
            _comets = new HashSet<EnemyModel>();
            for (int i = 0; i < 5; i++)
            {                
                _asteroids.Add(MakeModel(asteroid));
                _comets.Add(MakeModel(comet));                
            }

            gameController.EnemyModelTake(_asteroids, _comets);
        }

        private EnemyModel MakeModel(EnemyData enemyData)
        {
            var NewEnemyData = enemyData.enemyDataRelevant;
            var NewEnemyComponents = enemyData.enemyComponents;
            NewEnemyComponents.Rigidbody2D = NewEnemyData.EnemyPrefab.GetComponent<Rigidbody2D>();
            NewEnemyComponents.Transform = NewEnemyData.EnemyPrefab.GetComponent<Transform>();
            var NewEnemyModel = new EnemyModel(NewEnemyData, NewEnemyComponents);           
            return NewEnemyModel;
        }
    }
}

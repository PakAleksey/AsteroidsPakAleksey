using UnityEngine;
using AsteroidsPakAleksey.Object_Pool;
using System;


namespace AsteroidsPakAleksey
{
    public class EnemyController
    {
        private EnemyModel _enemyModel;
        private PlayerModel _playerModel;
        private Transform _rotPool;

        public EnemyController(EnemyModel enemyModel, PlayerModel playerModel)
        {
            _enemyModel = enemyModel;
            _playerModel = playerModel;
        }

        public void Health()
        {
            if (_enemyModel.EnemyDataRelevant.CurrentHealth <= 0.0f)
            {
                ReturnToPool();
            }
        }

        public Transform RotPool
        {
            get
            {
                if (_rotPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_AMMUNITION);
                    _rotPool = find == null ? null : find.transform;
                }

                return _rotPool;
            }
        }

        public EnemyModel CreateAsteroidEnemyWithPool(MyEnemyPool enemyPool)
        {
            var enemy = enemyPool.GetEnemy("Asteroid");
            enemy.EnemyDataRelevant.EnemyPrefab.transform.position = Vector3.one;
            enemy.EnemyDataRelevant.EnemyPrefab.SetActive(true);
            return enemy;
        }

        public void ActiveEnemy(Vector3 position, Quaternion rotation)
        {
            _enemyModel.EnemyDataRelevant.EnemyPrefab.transform.localPosition = position;
            _enemyModel.EnemyDataRelevant.EnemyPrefab.transform.localRotation = rotation;
            _enemyModel.EnemyDataRelevant.EnemyPrefab.SetActive(true);
            _enemyModel.EnemyDataRelevant.EnemyPrefab.transform.SetParent(null);
        }

        public void ReturnToPool()
        {
            _enemyModel.EnemyDataRelevant.EnemyPrefab.transform.localPosition = Vector3.zero;
            _enemyModel.EnemyDataRelevant.EnemyPrefab.transform.localRotation = Quaternion.identity;
            _enemyModel.EnemyDataRelevant.EnemyPrefab.SetActive(false);
            _enemyModel.EnemyDataRelevant.EnemyPrefab.transform.SetParent(RotPool);
        }
    }
}

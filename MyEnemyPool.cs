using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using AsteroidsPakAleksey.Object_Pool;


namespace AsteroidsPakAleksey
{
    public sealed class MyEnemyPool : EnemyPoolController
    {
        private readonly Dictionary<string, HashSet<EnemyModel>> _enemyPool;        
        private Transform _rootPool;

        public MyEnemyPool(HashSet<EnemyModel> asteroids, HashSet<EnemyModel> comets) : base(asteroids, comets)
        {
            _enemyPool = new Dictionary<string, HashSet<EnemyModel>>();
            _enemyPool.Add(NameManager.ASTEROID, _asteroids);
            _enemyPool.Add(NameManager.COMET, _comets);
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.POOL_AMMUNITION).transform;
            }
            foreach(var asteroidModel in _asteroids)
            {
                asteroidModel.EnemyDataRelevant.EnemyPrefab = GameObject.Instantiate(asteroidModel.EnemyDataRelevant.EnemyPrefab);
                ReturnToPool(asteroidModel.EnemyDataRelevant.EnemyPrefab.transform);
            }
            foreach (var cometModel in _comets)
            {
                cometModel.EnemyDataRelevant.EnemyPrefab = GameObject.Instantiate(cometModel.EnemyDataRelevant.EnemyPrefab);
                ReturnToPool(cometModel.EnemyDataRelevant.EnemyPrefab.transform);
            }
        }

        public EnemyModel GetEnemy(string type)
        {
            EnemyModel result;
            switch (type)
            {
                case "Asteroid":
                    result = GetEnemyType(GetListEnemies(type));
                    break;
                case "Comet":
                    result = GetEnemyType(GetListEnemies(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
            }

            return result;
        }

        private HashSet<EnemyModel> GetListEnemies(string type)
        {
            return _enemyPool.ContainsKey(type) ? _enemyPool[type] : _enemyPool[type] = new HashSet<EnemyModel>();
        }

        private EnemyModel GetEnemyType(HashSet<EnemyModel> enemies)
        {
            //var enemy = enemies.FirstOrDefault(a => !a.EnemyDataRelevant.EnemyPrefab.activeSelf);
            foreach(var enemy in enemies)
            {
                if (!enemy.EnemyDataRelevant.EnemyPrefab.activeSelf)
                {
                    return enemy;
                }
            }
            return null;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }
    }
}

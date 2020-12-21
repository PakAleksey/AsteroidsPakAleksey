using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using AsteroidsPakAleksey.Object_Pool;


namespace AsteroidsPakAleksey
{
    public sealed class BulletPool
    {
        private readonly List<GameObject> _bulletPool;
        private BulletModel _bulletModel;
        private Transform _rootPool;
        private const int _capacityPool = 5;


        public BulletPool(BulletModel bulletModel)
        {
            _bulletModel = bulletModel;
            _bulletPool = new List<GameObject>();
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.POOL_BULLETS).transform;
            }
        }

        public GameObject GetBullet()
        {
            var bullet = _bulletPool.FirstOrDefault(a => !a.activeSelf);
            if (bullet == null)
            {
                var laser = _bulletModel.DataBullet.BulletPrefab;
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(laser);
                    ReturnToPool(instantiate.transform);
                    _bulletPool.Add(instantiate);
                }
                GetBullet();
            }
            bullet = _bulletPool.FirstOrDefault(a => !a.activeSelf);
            return bullet;           
        }

        public void ReturnToPool(Transform transform)
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

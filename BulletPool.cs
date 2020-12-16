using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using AsteroidsPakAleksey.Object_Pool;


namespace AsteroidsPakAleksey
{
    public sealed class BulletPool
    {
        private readonly List<BulletModel> _bulletPool;
        private BulletModel _bulletModel;
        private readonly int _capacityPool;
        private Transform _rootPool;

        public BulletPool(List<BulletModel> bullets)
        {
            _bulletPool = bullets;
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.POOL_AMMUNITION).transform;
            }
            foreach(var bullet in _bulletPool)
            {
                bullet.DataBullet.BulletPrefab = Object.Instantiate(bullet.DataBullet.BulletPrefab);
                ReturnToPool(bullet.DataBullet.BulletPrefab.transform);
            }
        }

        public BulletModel GetBullet()
        {
            //var bullet = _bulletPool.FirstOrDefault(a => !a.DataBullet.BulletPrefab.activeSelf);
            foreach(var bullet in _bulletPool)
            {
                if (!bullet.DataBullet.BulletPrefab.activeSelf)
                {
                    return bullet;
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

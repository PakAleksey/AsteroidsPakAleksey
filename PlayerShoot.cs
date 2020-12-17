using UnityEngine;
using System;


namespace AsteroidsPakAleksey
{
    public sealed class PlayerShoot : PlayerController
    {
        private const float _limitTime = 5;
        private Timer _timer;
        private OnCollisionBullet _onCollisionBullet;
        private BulletPool _bulletPool;
        private BulletModel _bulletModel;
        public event Action<BulletModel> ReturnToPoolBullet = delegate { };
        private float _maxDistance;

        public PlayerShoot(PlayerModel playerModel, BulletPool bulletPool) : base(playerModel)
        {
            _timer = new Timer(_limitTime);
            _timer.StopTimer += ReturntoPoolBulletCollision;
            _bulletPool = bulletPool;            
            _maxDistance = 50;
        }

        public void Shoot()
        {
            _bulletModel = _bulletPool.GetBullet();
            _onCollisionBullet = _bulletModel.DataBullet.BulletPrefab.GetComponent<OnCollisionBullet>();
            _onCollisionBullet.ReturnToPoolBullet += ReturntoPoolBulletCollision;
            _bulletModel.DataBullet.BulletPrefab.transform.position = PlayerModel.playerComponents.Burrel.position;
            ActiveBullet();
            _bulletModel.DataBullet.BulletPrefab.GetComponent<Rigidbody2D>().AddForce(PlayerModel.playerComponents.Burrel.up * _bulletModel.DataBullet.Force);
            _timer.IsStart = true;
            _timer.TimerGo();
        }

        private void ActiveBullet()
        {
            _bulletModel.DataBullet.BulletPrefab.transform.SetParent(null);
            _bulletModel.DataBullet.BulletPrefab.SetActive(true);
        }

        private void ReturntoPoolBulletCollision()
        {
            _bulletPool.ReturnToPool(_bulletModel.DataBullet.BulletPrefab.transform);
        }

    }
}

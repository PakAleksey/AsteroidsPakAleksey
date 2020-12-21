using UnityEngine;


namespace AsteroidsPakAleksey
{
    public sealed class PlayerShoot : PlayerController
    {
        private BulletPool _bulletPool;
        private BulletModel _bulletModel;
        private GameObject _bullet;       

        public PlayerShoot(PlayerModel playerModel, BulletPool bulletPool, BulletModel bulletModel) : base(playerModel)
        {
            _bulletModel = bulletModel;
            _bulletPool = bulletPool;            
        }

        public void Shoot()
        {
            _bullet = _bulletPool.GetBullet();
            var onCollision = _bullet.GetComponent<OnCollisionBullet>();
            var timerReturnToPool = _bullet.GetComponent<TimerReturnToPool>();
            onCollision.ReturnToPoolBullet += ReturntoPoolBulletCollision;
            timerReturnToPool.ReturnToPoolBullet += ReturntoPoolBulletCollision;
            _bullet.transform.position = PlayerModel.playerComponents.Burrel.position;
            ActiveBullet();
            _bullet.GetComponent<Rigidbody2D>().AddForce(PlayerModel.playerComponents.Burrel.up * _bulletModel.DataBullet.Force);
            timerReturnToPool.GoCoroutine();
        }

        private void ActiveBullet()
        {
            _bullet.transform.SetParent(null);
            _bullet.SetActive(true);
        }

        private void ReturntoPoolBulletCollision()
        {
            _bulletPool.ReturnToPool(_bullet.transform);
            _bullet.GetComponent<OnCollisionBullet>().ReturnToPoolBullet -= ReturntoPoolBulletCollision;
            _bullet.GetComponent<TimerReturnToPool>().ReturnToPoolBullet -= ReturntoPoolBulletCollision;
        }
    }
}

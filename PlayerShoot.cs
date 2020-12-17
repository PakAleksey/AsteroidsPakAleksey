using UnityEngine;


namespace AsteroidsPakAleksey
{
    public sealed class PlayerShoot : PlayerController
    {
        private BulletPool _bulletPool;
        private BulletModel _bulletModel;       

        public PlayerShoot(PlayerModel playerModel, BulletPool bulletPool) : base(playerModel)
        {
            _bulletPool = bulletPool;            
        }

        public void Shoot()
        {
            _bulletModel = _bulletPool.GetBullet();
            _bulletModel.DataBullet.BulletPrefab.GetComponent<OnCollisionBullet>().ReturnToPoolBullet += ReturntoPoolBulletCollision;
            _bulletModel.DataBullet.BulletPrefab.GetComponent<TimerReturnToPool>().ReturnToPoolBullet += ReturntoPoolBulletCollision;
            _bulletModel.DataBullet.BulletPrefab.transform.position = PlayerModel.playerComponents.Burrel.position;
            ActiveBullet();
            _bulletModel.DataBullet.BulletPrefab.GetComponent<Rigidbody2D>().AddForce(PlayerModel.playerComponents.Burrel.up * _bulletModel.DataBullet.Force);
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

using UnityEngine;


namespace AsteroidsPakAleksey
{
    public sealed class PlayerShoot : PlayerController
    {
        private BulletModel _bulletModel;
        public PlayerShoot(PlayerModel playerModel, BulletModel _bulletModel) : base(playerModel)
        {
            this._bulletModel = _bulletModel;
        }
        public void Shoot()
        {
            var temAmmunition = Object.Instantiate(_bulletModel.BulletComponents.BulletRigidBody, PlayerModel.playerComponents.Burrel.position,
                PlayerModel.playerComponents.Burrel.rotation);
            temAmmunition.AddForce(PlayerModel.playerComponents.Burrel.up * _bulletModel.DataBullet.Force);
        }
    }
}

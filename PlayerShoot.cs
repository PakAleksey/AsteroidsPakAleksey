using UnityEngine;


namespace AsteroidsPakAleksey
{
    public sealed class PlayerShoot : PlayerController
    {
        public PlayerShoot(PlayerModel playerModel) : base(playerModel)
        {
            
        }

        public void Shoot(BulletModel bulletModel)
        {
            bulletModel.DataBullet.BulletPrefab.transform.position = PlayerModel.playerComponents.Burrel.position;
            ActiveBullet(bulletModel);
            bulletModel.DataBullet.BulletPrefab.GetComponent<Rigidbody2D>().AddForce(PlayerModel.playerComponents.Burrel.up * bulletModel.DataBullet.Force);
        }

        private void ActiveBullet(BulletModel bulletModel)
        {
            bulletModel.DataBullet.BulletPrefab.transform.SetParent(null);
            bulletModel.DataBullet.BulletPrefab.SetActive(true);
        }
    }
}

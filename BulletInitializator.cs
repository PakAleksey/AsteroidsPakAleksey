using UnityEngine;
using System.Collections.Generic;


namespace AsteroidsPakAleksey
{
    public sealed class BulletInitializator
    {
        private List<BulletModel> _bullets;
        private const int _maxBullets = 50;

        public BulletInitializator(GameController gameController, BulletData bulletData)
        {
            _bullets = new List<BulletModel>();
            for (int i = 0; i < _maxBullets; i++)
            {
                _bullets.Add(MakeBullet(bulletData));
            }
            gameController.BulletModelTake(_bullets);
        }

        private BulletModel MakeBullet(BulletData bulletData)
        {
            var NewBulletData = bulletData.DataBulletRelevant;
            var NewBulletComponents = bulletData.DataBulletComponents;
            NewBulletComponents.BulletRigidBody = NewBulletData.BulletPrefab.GetComponent<Rigidbody2D>();
            var BulletModel = new BulletModel(NewBulletComponents, NewBulletData);
            return BulletModel;
        }
    }
}

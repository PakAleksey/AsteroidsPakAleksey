using UnityEngine;
using System.Collections.Generic;


namespace AsteroidsPakAleksey
{
    public sealed class BulletInitializator
    {
        private List<BulletModel> _bullets;

        public BulletInitializator(GameController gameController, BulletData bulletData)
        {
            _bullets = new List<BulletModel>();
            for (int i = 0; i < 50; i++)
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

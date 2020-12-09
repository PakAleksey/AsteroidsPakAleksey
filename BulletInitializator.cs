using UnityEngine;


namespace AsteroidsPakAleksey
{
    public sealed class BulletInitializator
    {        
        public BulletInitializator(GameController gameController, BulletData bulletData)
        {
            var NewBulletData = bulletData.DataBulletRelevant;           

            var NewBulletComponents = bulletData.DataBulletComponents;
            NewBulletComponents.BulletRigidBody = NewBulletData.BulletPrefab.GetComponent<Rigidbody2D>();          

            var BulletModel = new BulletModel(NewBulletComponents, NewBulletData);
            gameController.BulletModelTake(BulletModel);
        }
    }
}

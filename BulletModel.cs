using UnityEngine;


namespace AsteroidsPakAleksey
{
    public sealed class BulletModel
    {
        public DataBulletComponents BulletComponents;
        public DataBulletRelevant DataBullet;

        public BulletModel(DataBulletComponents bulletComponents, DataBulletRelevant dataBulletRelevant)
        {
            BulletComponents = bulletComponents;
            DataBullet = dataBulletRelevant;
        }
    }
}

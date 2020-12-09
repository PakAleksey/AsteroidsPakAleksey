using UnityEngine;


namespace AsteroidsPakAleksey
{
    [CreateAssetMenu(fileName = "BulletData", menuName = "Data/BulletData")]
    public class BulletData : ScriptableObject
    {
        public DataBulletRelevant DataBulletRelevant;
        public DataBulletComponents DataBulletComponents;
    }
}

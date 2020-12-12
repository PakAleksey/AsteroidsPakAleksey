using UnityEngine;


namespace AsteroidsPakAleksey
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Data/EnemyData")]
    public sealed class EnemyData : ScriptableObject
    {
        public EnemyDataRelevant enemyDataRelevant;
        public EnemyComponents enemyComponents;
    }
}

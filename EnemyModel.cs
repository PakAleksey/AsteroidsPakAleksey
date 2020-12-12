using System;
using UnityEngine;


namespace AsteroidsPakAleksey
{
    public sealed class EnemyModel
    {
        public EnemyDataRelevant EnemyDataRelevant;
        public EnemyComponents EnemyComponents;

        public EnemyModel(EnemyDataRelevant EnemyDataRelevant, EnemyComponents EnemyComponents)
        {
            this.EnemyDataRelevant = EnemyDataRelevant;
            this.EnemyComponents = EnemyComponents;

        }
    }
}

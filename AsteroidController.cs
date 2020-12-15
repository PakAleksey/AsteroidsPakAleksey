using UnityEngine;


namespace AsteroidsPakAleksey
{
    public sealed class AsteroidController : EnemyController
    {
        public static AsteroidControllerFactory AsteroidControllerFactory = new AsteroidControllerFactory();
        public AsteroidController(EnemyModel enemyModel, PlayerModel playerModel) : base(enemyModel, playerModel)
        {

        }
    }
}

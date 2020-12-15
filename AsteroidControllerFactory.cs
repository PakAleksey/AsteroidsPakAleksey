using System.Collections.Generic;


namespace AsteroidsPakAleksey
{
    public sealed class AsteroidControllerFactory : IAsteroidControllerFactory
    {
        public AsteroidController Create(EnemyModel enemyModel, PlayerModel playerModel )
        {
            return new AsteroidController(enemyModel, playerModel);
        }
    }
}

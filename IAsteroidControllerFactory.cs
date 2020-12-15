using System.Collections.Generic;


namespace AsteroidsPakAleksey
{
    public interface IAsteroidControllerFactory
    {
        AsteroidController Create(EnemyModel enemyModel, PlayerModel playerModel);
    }
}

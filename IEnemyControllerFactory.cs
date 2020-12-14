using System.Collections.Generic;


namespace AsteroidsPakAleksey
{
    public interface IEnemyControllerFactory
    {
        EnemyController Create(List<EnemyModel> asteroids, List<EnemyModel> comets);
    }
}

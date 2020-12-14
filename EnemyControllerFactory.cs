using System.Collections.Generic;


namespace AsteroidsPakAleksey
{
    public sealed class EnemyControllerFactory : IEnemyControllerFactory
    {
        public EnemyController Create(List<EnemyModel> asteroids, List<EnemyModel> comets)
        {
            return new EnemyController(asteroids, comets);
        }
    }
}

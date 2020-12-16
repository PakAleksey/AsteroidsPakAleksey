using System.Collections.Generic;
using UnityEngine;


namespace AsteroidsPakAleksey
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private BulletData _bulletData;
        [SerializeField] private EnemyData _enemyDataAsteroid;
        [SerializeField] private EnemyData _enemyDataComet;
        private AsteroidControllerFactory _asteroidControllerFactory;
        private HashSet<EnemyModel> _asteroids;
        private HashSet<EnemyModel> _comets;
        private PlayerModel _playerModel;
        private PlayerMoveTransform _playerMoveTransform;
        private PlayerRotation _playerRotation;
        private PlayerShoot _playerShoot;
        private BulletPool _bulletPool;
        private BuffSpeed _buffSpeed;
        private MyEnemyPool _myEnemyPool;
        private AsteroidController _asteroidController;
        private AsteroidController _asteroidController2;
        private CometController _cometController;
        private Camera _camera;
        private Timer _timer;

        public void PlayerModelTake(PlayerController playerController)
        {
            _playerModel = playerController.PlayerModel;    
            _playerMoveTransform = new PlayerMoveTransform(_playerModel);
            _playerRotation = new PlayerRotation(_playerModel);
            _buffSpeed = new BuffSpeed(_playerModel);
        }

        public void BulletModelTake(List<BulletModel> bullets)
        {
            _bulletPool = new BulletPool(bullets);
            _playerShoot = new PlayerShoot(_playerModel);              
        }

        public void EnemyModelTake(HashSet<EnemyModel> asteroids, HashSet<EnemyModel> comets)
        {
            _asteroids = asteroids;
            _comets = comets;
            _myEnemyPool = new MyEnemyPool(_asteroids, _comets);
        }

        private void Start()
        {
            _timer = new Timer();
            _camera = Camera.main;
            new PlayerInitializator(this, _playerData);
            new BulletInitializator(this, _bulletData);
            new EnemyInitializator(this, _enemyDataAsteroid, _enemyDataComet);
            _asteroidController = AsteroidController.AsteroidControllerFactory.Create(_myEnemyPool.GetEnemy("Asteroid"), _playerModel);
            _asteroidController.ActiveEnemy(new Vector3(0,0), Quaternion.identity);
            _asteroidController2 = AsteroidController.AsteroidControllerFactory.Create(_myEnemyPool.GetEnemy("Asteroid"), _playerModel);
            _asteroidController2.ActiveEnemy(new Vector3(0, 0), Quaternion.identity);
            _cometController = new CometController(_myEnemyPool.GetEnemy("Comet"), _playerModel);
            //_cometController.ActiveEnemy(Vector3.one, Quaternion.identity);
        }

        private void Update()
        {
            _timer.TimerGo();
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _playerRotation.Rotation(direction);

            _playerMoveTransform.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _buffSpeed.AddBuffSpeed();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _buffSpeed.RemoveBuffSpeed();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                _playerShoot.Shoot(_bulletPool.GetBullet());
            }

            _asteroidController.Move();
            _asteroidController.DistanceToPlayer();
            _asteroidController2.Move();
            _asteroidController2.DistanceToPlayer();
        }
    }
}

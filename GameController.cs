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
        private EnemyControllerFactory _enemyControllerFactory;
        private List<EnemyModel> _asteroids;
        private List<EnemyModel> _comets;
        private PlayerModel _playerModel;
        private PlayerMoveTransform _playerMoveTransform;
        private PlayerRotation _playerRotation;
        private PlayerShoot _playerShoot;
        private BuffSpeed _buffSpeed;
        private EnemyController _enemyController;
        private Camera _camera;

        public void PlayerModelTake(PlayerController playerController)
        {
            _playerModel = playerController.PlayerModel;    
            _playerMoveTransform = new PlayerMoveTransform(_playerModel);
            _playerRotation = new PlayerRotation(_playerModel);
            _buffSpeed = new BuffSpeed(_playerModel);
        }

        public void BulletModelTake(BulletModel _bulletModel)
        {
            _playerShoot = new PlayerShoot(_playerModel, _bulletModel);           
        }

        public void EnemyModelTake(List<EnemyModel> asteroids, List<EnemyModel> comets)
        {
            _asteroids = asteroids;
            _comets = comets;
            //_enemyController = new EnemyController(_asteroids, _comets);
        }

        private void Start()
        {            
            _camera = Camera.main;
            new PlayerInitializator(this, _playerData);
            new BulletInitializator(this, _bulletData);
            new EnemyInitializator(this, _enemyDataAsteroid, _enemyDataComet);
            _enemyControllerFactory = new EnemyControllerFactory();
            _enemyController = _enemyControllerFactory.Create(_asteroids, _comets);
            _playerModel.playerDataRelevant.PlayerPrefab.GetComponent<OnCollisionPlayer>().GetPlayerModel(_playerModel);
            //_enemyController = EnemyController.EnemyControllerFactory.Create(_asteroids, _comets);
            _enemyController.InstantiateEnemy();
        }

        private void Update()
        {
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
                _playerShoot.Shoot();
            }
        }
    }
}

using System;
using UnityEngine;


namespace AsteroidsPakAleksey
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private BulletData _bulletData;
        protected PlayerModel _playerModel;
        private PlayerMoveTransform _playerMoveTransform;
        private PlayerRotation _playerRotation;
        private PlayerShoot _playerShoot;
        private BuffSpeed _buffSpeed;
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

        private void Start()
        {            
            _camera = Camera.main;
            new PlayerInitializator(this, _playerData);
            new BulletInitializator(this, _bulletData);
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

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_playerModel.playerDataIndividual.Health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _playerModel.playerDataIndividual.Health--;
            }
        }
    }
}

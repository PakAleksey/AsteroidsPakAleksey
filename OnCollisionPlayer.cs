using UnityEngine;


namespace AsteroidsPakAleksey
{
    public sealed class OnCollisionPlayer : MonoBehaviour
    {
        private PlayerModel _playerModel;

        public void GetPlayerModel(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_playerModel.playerDataRelevant.CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _playerModel.playerDataRelevant.CurrentHealth--;
            }
        }
    }
}

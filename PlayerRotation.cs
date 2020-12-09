using UnityEngine;


namespace AsteroidsPakAleksey
{
    public sealed class PlayerRotation : PlayerController
    {
        public PlayerRotation(PlayerModel playerModel) : base(playerModel)
        {
        }

        public void Rotation(Vector3 direction)
        {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            PlayerModel.playerComponents.PlayerTransform.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}

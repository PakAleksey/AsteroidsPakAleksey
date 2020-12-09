using UnityEngine;


namespace AsteroidsPakAleksey
{
    public sealed class PlayerMoveTransform : PlayerController
    {
        public PlayerMoveTransform(PlayerModel playerModel) : base(playerModel)
        {

        }
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * PlayerModel.playerDataIndividual.Speed;
            PlayerModel.playerDataIndividual.Move.Set(horizontal * speed, vertical * speed, 0.0f);
            PlayerModel.playerComponents.PlayerTransform.localPosition += PlayerModel.playerDataIndividual.Move;
        }
    }
}

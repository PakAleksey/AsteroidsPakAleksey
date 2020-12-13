using UnityEngine;


namespace AsteroidsPakAleksey
{
    public sealed class PlayerMoveTransform : PlayerController, IMove
    {
        public PlayerMoveTransform(PlayerModel playerModel) : base(playerModel)
        {

        }
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * PlayerModel.playerDataRelevant.Speed;
            PlayerModel.playerDataRelevant.Move.Set(horizontal * speed, vertical * speed, 0.0f);
            PlayerModel.playerComponents.PlayerTransform.localPosition += PlayerModel.playerDataRelevant.Move;
        }
    }
}

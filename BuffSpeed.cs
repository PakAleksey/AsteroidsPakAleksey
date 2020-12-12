using UnityEngine;


namespace AsteroidsPakAleksey
{
    public sealed class BuffSpeed : PlayerController
    {
        public BuffSpeed(PlayerModel playerModel) : base(playerModel)
        {
        }
        public void AddBuffSpeed()
        {
            PlayerModel.playerDataRelevant.Speed += PlayerModel.playerDataRelevant.Acceleration;
        }

        public void RemoveBuffSpeed()
        {
            PlayerModel.playerDataRelevant.Speed -= PlayerModel.playerDataRelevant.Acceleration;
        }
    }
}

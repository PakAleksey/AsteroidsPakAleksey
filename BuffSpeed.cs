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
            PlayerModel.playerDataIndividual.Speed += PlayerModel.playerDataIndividual.Acceleration;
        }

        public void RemoveBuffSpeed()
        {
            PlayerModel.playerDataIndividual.Speed -= PlayerModel.playerDataIndividual.Acceleration;
        }
    }
}

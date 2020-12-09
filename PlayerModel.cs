namespace AsteroidsPakAleksey
{
    public sealed class PlayerModel
    {
        public PlayerDataRelevant playerDataIndividual;
        public PlayerComponents playerComponents;

        public PlayerModel(PlayerDataRelevant playerDataIndividual, PlayerComponents playerComponents)
        {
            this.playerDataIndividual = playerDataIndividual;
            this.playerComponents = playerComponents;
        }
    }
}

namespace AsteroidsPakAleksey
{
    public sealed class PlayerModel
    {
        public PlayerDataRelevant playerDataRelevant;
        public PlayerComponents playerComponents;

        public PlayerModel(PlayerDataRelevant playerDataIndividual, PlayerComponents playerComponents)
        {
            this.playerDataRelevant = playerDataIndividual;
            this.playerComponents = playerComponents;
        }
    }
}

using UnityEngine;


namespace AsteroidsPakAleksey
{
    public sealed class PlayerInitializator
    {
        public PlayerInitializator(GameController mainController, PlayerData playerData)
        {
            var spawnedPlayer = Object.Instantiate(playerData.playerDataIndividual.PlayerPrefab,
            Vector3.zero, Quaternion.identity);

            var NewPlayerDataIndividual = playerData.playerDataIndividual;
            NewPlayerDataIndividual.PlayerPrefab = spawnedPlayer;

            var NewPlayerComponents = playerData.playerComponents;
            NewPlayerComponents.PlayerTransform = spawnedPlayer.GetComponentInChildren<Transform>();
            NewPlayerComponents.Burrel = spawnedPlayer.GetComponentsInChildren<Transform>()[1];

            var PlayerModel = new PlayerModel(NewPlayerDataIndividual, NewPlayerComponents);
            mainController.PlayerModelTake(new PlayerController(PlayerModel));
        }
    }
}

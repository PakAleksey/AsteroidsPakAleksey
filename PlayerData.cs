using UnityEngine;


namespace AsteroidsPakAleksey
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
    public sealed class PlayerData : ScriptableObject
    {
        public PlayerDataRelevant playerDataIndividual;
        public PlayerComponents playerComponents;
    }
}

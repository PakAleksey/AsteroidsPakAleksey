using UnityEngine;

namespace AsteroidsPakAleksey
{
    public class PlayerController
    {
        public static AsteroidControllerFactory PlayerControllerFactory;
        public PlayerModel PlayerModel;       

        public PlayerController(PlayerModel playerModel)
        {
            PlayerModel = playerModel;
        }        
    }
}

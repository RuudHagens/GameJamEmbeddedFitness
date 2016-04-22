using Assets.Scripts.Base;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : Singleton<GameManager>
    {
        public WorldGen WorldGen;
        public Player Player;

        // Use this for initialization
        private void Start()
        {
            if (!WorldGen)
            {
                Debug.LogError(string.Format("{0}: WorldGen is not set.", name));
                return;
            }
            if (!Player)
            {
                Debug.LogError(string.Format("{0}: Player is not set.", name));
                return;
            }
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}
using Assets.Scripts.Base;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : Singleton<GameManager>
    {
        public WorldGen WorldGen;

        // Use this for initialization
        private void Start()
        {
            // Set image for user.
            HUDManager.Instance.SelectedSprite = WorldGen.SpritesToPlace[Random.Range(0, WorldGen.SpritesToPlace.Count - 1)];
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}
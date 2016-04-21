using Assets.Scripts.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HUDManager : Singleton<HUDManager>
    {
        public Image SpriteImage;

        /// <summary>
        /// Current select sprite that is visible on UI.
        /// </summary>
        public Sprite SelectedSprite
        {
            get { return SpriteImage.sprite; }
            set { SpriteImage.sprite = value; }
        }

        // Use this for initialization
        private void Start()
        {
        }
    }
}
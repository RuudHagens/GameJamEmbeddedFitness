using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        /// <summary>
        ///     Index of the player as defined by <see cref="GameManager" />.
        /// </summary>
        public int Index;

        [HideInInspector]
        public SpriteRenderer Render;

        [HideInInspector]
        public Rigidbody2D Body;

        [HideInInspector]
        public PlayerCanvasContainer Hud;

        // Use this for initialization
        public void Start()
        {
            Render = GetComponent<SpriteRenderer>();
            Render.sprite =
                GameManager.Instance.WorldGen.AvailableSprites[
                    Random.Range(0, GameManager.Instance.WorldGen.AvailableSprites.Count - 1)];

            Body = GetComponent<Rigidbody2D>();

            // Hud is set by GameManager.
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}
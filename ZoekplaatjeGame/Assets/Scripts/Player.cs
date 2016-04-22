using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Player : MonoBehaviour
    {
        [HideInInspector]
        public SpriteRenderer Render;

        // Use this for initialization
        public void Start()
        {
            Render = GetComponent<SpriteRenderer>();
            Render.sprite = GameManager.Instance.WorldGen.AvailableSprites[Random.Range(0, GameManager.Instance.WorldGen.AvailableSprites.Count - 1)];
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}
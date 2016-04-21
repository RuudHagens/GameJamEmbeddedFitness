using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
    public class ColoredCollider : MonoBehaviour
    {
        private WorldGen gen;
        private BoxCollider2D box;
        private SpriteRenderer render;

        // Use this for initialization
        private void Start()
        {
            gen = GetComponentInParent<WorldGen>();
            transform.localScale = new Vector3(gen.SizeInMeters / 4f, .1f, .1f);

            box = GetComponent<BoxCollider2D>();
            box.size = new Vector2(4, 4);

            render = GetComponent<SpriteRenderer>();
            render.sprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0, 0, 4, 4), new Vector2(.5f, .5f), 1f);
            render.color = Color.black;
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}
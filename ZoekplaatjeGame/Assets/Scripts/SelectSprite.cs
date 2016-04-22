using System;
using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts
{
    public class SelectSprite : MonoBehaviour
    {
        public event EventHandler<SpriteSelectedEventArgs> SpriteSelected;
        private SpriteRenderer render;

        // Use this for initialization
        private void Start()
        {
            render = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Sprite")) return;
            var otherSprite = other.GetComponent<SpriteRenderer>();
            otherSprite.color = Color.white;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Sprite")) return;
            var otherSprite = other.GetComponent<SpriteRenderer>();
            if (otherSprite.sprite == render.sprite)
            {
                OnSpriteSelected(new SpriteSelectedEventArgs(otherSprite.sprite));
                Destroy(other.gameObject);
            }
            else
            {
                otherSprite.color = Color.red;
            }
        }

        protected virtual void OnSpriteSelected(SpriteSelectedEventArgs e)
        {
            var handler = SpriteSelected;
            if (handler != null) handler(this, e);
        }
    }
}
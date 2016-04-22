using System;
using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Player), typeof(SpriteRenderer))]
    public class SelectSprite : MonoBehaviour
    {
        public event EventHandler<SpriteSelectedEventArgs> SpriteSelected;

        private SpriteRenderer render;
        private Player player;

        // Use this for initialization
        private void Start()
        {
            render = GetComponent<SpriteRenderer>();
            player = GetComponent<Player>();
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
                player.Hud.PlayerScore++;
                CheckFinished();
                OnSpriteSelected(new SpriteSelectedEventArgs(otherSprite.sprite));
                Destroy(other.gameObject);
            }
            else
            {
                otherSprite.color = Color.red;
            }
        }

        private void CheckFinished()
        {
            if (player.Hud.PlayerScore >= GameManager.Instance.WorldGen.AmountOfSpritesPerPlayer)
            {
                // Fade out and display.
                player.Hud.Done = true;
                player.gameObject.SetActive(false);
            }
        }

        protected virtual void OnSpriteSelected(SpriteSelectedEventArgs e)
        {
            var handler = SpriteSelected;
            if (handler != null) handler(this, e);
        }
    }
}
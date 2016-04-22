using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class SelectSprite : MonoBehaviour
    {
        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Sprite")) return;

            if (other.GetComponent<SpriteRenderer>().sprite == HUDManager.Instance.SelectedSprite)
            {
                Destroy(other.gameObject);

                HUDManager.Instance.SelectedSprite = null;
            }
        }
    }
}
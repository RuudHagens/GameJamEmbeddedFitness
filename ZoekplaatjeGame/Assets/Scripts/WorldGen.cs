using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WorldGen : MonoBehaviour
    {
        [Header("Prefabs")]
        public GameObject WallPrefab;

        public GameObject SpritePrefab;


        private Transform wallParent;
        private Transform spriteParent;

        [Header("Misc")]
        public float SizeInMeters;

        public int AmountOfSprites;

        /// <summary>
        /// Sprites that will be placed on the field.
        /// </summary>
        public List<Sprite> AvailableSprites;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, new Vector3(SizeInMeters, SizeInMeters, .1f));
        }

        private void Reset()
        {
            AmountOfSprites = 5;
        }

        // Use this for initialization
        private void Start()
        {
            if (!WallPrefab)
            {
                Debug.LogError(string.Format("{0}: No prefab for wall set.", name));
                enabled = false;
                return;
            }

            var wallContainer = new GameObject("Walls");
            wallContainer.transform.SetParent(transform);
            wallParent = wallContainer.transform;

            spriteParent = new GameObject("Sprites").transform;
            spriteParent.SetParent(transform);

            // Spawn walls on edge of playfield.
            AddWall("Top", transform.up);
            AddWall("Right", transform.right);
            AddWall("Down", -transform.up);
            AddWall("Left", -transform.right);

            Generate();
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void AddWall(string wallName, Vector3 direction)
        {
            // Create wall.
            var wall = Instantiate(WallPrefab);
            wall.name = wallName;
            if (direction == transform.right || direction == -transform.right)
                wall.transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);

            // Add collision box.
            wall.GetComponent<BoxCollider2D>().size = new Vector3(10, .1f, .1f);
            wall.transform.position = transform.position + direction * (SizeInMeters / 2f);

            wall.transform.SetParent(wallParent);
        }

        private void Generate()
        {
            for (var i = 0; i < AmountOfSprites; i++)
            {
                var newSprite =
                    (GameObject)
                        Instantiate(SpritePrefab,
                            new Vector2(Random.Range(-SizeInMeters / 2f + 1, SizeInMeters / 2f - 1),
                                Random.Range(-SizeInMeters / 2f + 1, SizeInMeters / 2f - 1)), Quaternion.identity);

                var spriteRenderer = newSprite.GetComponent<SpriteRenderer>();

                // First one should always spawn selected image that player needs.
                spriteRenderer.sprite = i == 0 ? GameManager.Instance.Player.Render.sprite : AvailableSprites[Random.Range(0, AvailableSprites.Count - 1)];
                spriteRenderer.name = spriteRenderer.sprite.name;

                newSprite.transform.SetParent(spriteParent);
            }
        }
    }
}
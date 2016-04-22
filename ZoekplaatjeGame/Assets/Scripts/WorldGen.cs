using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        ///     Amount of sprites that are on the field for each player.
        /// </summary>
        public int AmountOfSpritesPerPlayer;

        /// <summary>
        ///     Amount of sprites that are spawned that no player can pick-up. 0 is no extra sprites, 1 is 100% extra sprites.
        /// </summary>
        [Tooltip("Amount of sprites that are spawned that no player can pick-up.")]
        [Range(0, 5)]
        public float AmountOfExtraSprites;

        /// <summary>
        ///     Sprites that will be placed on the field.
        /// </summary>
        public List<Sprite> AvailableSprites;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, new Vector3(SizeInMeters, SizeInMeters, .1f));
        }

        private void Reset()
        {
            AmountOfSpritesPerPlayer = 5;
            AmountOfExtraSprites = 1f;
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

            GenerateWorld();
            AssignPlayerSprites();
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

        private void GenerateWorld()
        {
            // Spawn sprites for players to pick up.
            for (var i = 0; i < GameManager.Instance.Players.Count(); i++)
            {
                for (var j = 0; j < AmountOfSpritesPerPlayer; j++)
                {
                    AddRandomPositionSprite(AvailableSprites[i]);
                }
            }

            // Spawn extra 'fake' sprites.
            for (var i = 0;
                i < AmountOfSpritesPerPlayer * GameManager.Instance.Players.Count() * AmountOfExtraSprites;
                i++)
            {
                AddRandomPositionSprite(
                    AvailableSprites[Random.Range(GameManager.Instance.Players.Count(), AvailableSprites.Count)]);
            }
        }

        private void AddRandomPositionSprite(Sprite sprite)
        {
            var obj =
                (GameObject)
                    Instantiate(SpritePrefab,
                        new Vector2(Random.Range(-SizeInMeters / 2f + 1, SizeInMeters / 2f - 1),
                            Random.Range(-SizeInMeters / 2f + 1, SizeInMeters / 2f - 1)), Quaternion.identity);

            var spriteScript = obj.GetComponent<SpriteRenderer>();
            spriteScript.sprite = sprite;

            obj.transform.SetParent(spriteParent);
        }

        /// <summary>
        ///     Assigns sprites to the players on the field in order.
        /// </summary>
        private void AssignPlayerSprites()
        {
            var i = 0;
            foreach (var player in GameManager.Instance.Players)
            {
                player.Render.sprite = AvailableSprites[i];
                i++;
            }
        }
    }
}
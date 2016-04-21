using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WorldGen : MonoBehaviour
    {
        private Transform wallParent;
        public GameObject WallPrefab;
        public float SizeInMeters;
        public List<Sprite> SpritesToPlace; 


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, new Vector3(SizeInMeters, SizeInMeters, .1f));
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
            GameObject wall = new GameObject(wallName);
            if (direction == transform.right || direction == -transform.right)
                wall.transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);

            // Add collision box.
            var coll = wall.AddComponent<BoxCollider2D>();
            coll.size = new Vector3(SizeInMeters, .1f);
            wall.transform.position = transform.position + direction * (SizeInMeters / 2f);

            wall.transform.SetParent(wallParent);
        }

        private void Generate()
        {
            
        }
    }
}
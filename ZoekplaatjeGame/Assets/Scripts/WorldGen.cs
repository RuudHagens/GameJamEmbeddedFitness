using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WorldGen : MonoBehaviour
    {
        private Transform wallParent;
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
            wallParent = new GameObject("Walls").transform;
            // Spawn walls on edge of playfield.
            AddWall("Top", transform.up);
            AddWall("Right", transform.right);
            AddWall("Down", -transform.up);
            AddWall("Left", -transform.right);
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
            coll.size = new Vector3(10, .1f);
            wall.transform.position = transform.position + direction * (SizeInMeters / 2f);

            wall.transform.SetParent(wallParent);
        }

        private void Generate()
        {
            
        }
    }
}
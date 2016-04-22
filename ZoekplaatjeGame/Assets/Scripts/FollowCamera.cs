﻿using UnityEngine;

namespace Assets.Scripts
{
    public class FollowCamera : MonoBehaviour
    {
        public Transform Target;

        private void Awake()
        {
            if (!Target)
            {
                Debug.LogWarning("No target set for FollowCamera to follow.");
                enabled = false;
            }
        }

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            if (!Target) return;
            transform.position = new Vector3(Target.position.x, Target.position.y, transform.position.z);
        }
    }
}
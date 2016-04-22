using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Camera))]
    public class PlayAreaCamera : MonoBehaviour
    {
        /// <summary>
        ///     Target to follow around.
        /// </summary>
        public Transform Target;

        /// <summary>
        ///     Camera script that this script is a sibling of.
        /// </summary>
        public Camera Cam { get; private set; }

        private void Awake()
        {
        }

        // Use this for initialization
        private void Start()
        {
            Cam = GetComponent<Camera>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (!Target) return;
            transform.position = new Vector3(Target.position.x, Target.position.y, transform.position.z);
        }
    }
}
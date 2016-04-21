using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class InputMovement : MonoBehaviour
    {
        public float MoveSpeed;
        private Rigidbody2D body;

        private void Awake()
        {
            
        }

        // Use this for initialization
        private void Start()
        {
            body = GetComponent<Rigidbody2D>();
            if (!body)
            {
                Debug.LogWarning(string.Format("Object {0} does not have a rigidbody.", name));
                enabled = false;
            }
        }

        private void Reset()
        {
            MoveSpeed = 1;
        }

        // Update is called once per frame
        private void Update()
        {
            body.AddForce(new Vector3(Input.GetAxis("Horizontal") * MoveSpeed, Input.GetAxis("Vertical") * MoveSpeed), ForceMode2D.Impulse);
        }
    }
}
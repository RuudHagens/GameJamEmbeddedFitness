using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class InputMovement : MonoBehaviour
    {
        private Player player;
        public float MoveSpeed;
        private Rigidbody2D body;
        private string HorAxis;
        private string VerAxis;

        private void Awake()
        {
            
        }

        // Use this for initialization
        private void Start()
        {
            player = GetComponent<Player>();
            body = GetComponent<Rigidbody2D>();
            if (!body)
            {
                Debug.LogWarning(string.Format("Object {0} does not have a rigidbody.", name));
                enabled = false;
            }

            HorAxis = "Horizontal" + (player.Index + 1);
            VerAxis = "Vertical" + (player.Index + 1);
        }

        private void Reset()
        {
            body.drag = 7;
            MoveSpeed = 20;
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            body.AddForce(new Vector3(Input.GetAxis(HorAxis) * MoveSpeed, Input.GetAxis(VerAxis) * MoveSpeed), ForceMode2D.Impulse);
        }
    }
}
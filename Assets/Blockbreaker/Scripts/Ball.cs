using UnityEngine;

namespace Blockbreaker
{
    /// <summary>
    /// 
    /// </summary>
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        private float constantSpeed = 10f;

        private Vector3 lastFrameVelocity;
        private Rigidbody2D rb;

        private Player player;
        private Vector3 playerOffset;

        private bool active = false;

        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            player = FindObjectOfType<Player>();
            playerOffset = transform.position - player.transform.position;
            ResetBall();
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartBallMovement()
        {
            transform.parent = null;
            rb.velocity = new Vector3(constantSpeed, constantSpeed, 0);
            active = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            lastFrameVelocity = rb.velocity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!active)
                return;

            
            Bounce(collision.contacts[0].normal);
            if (collision.gameObject.tag == "Player")
            {
                //set multiplier to 0
                GameManager.Instance.ResetScoreMultiplier();
                
            }
            else if (collision.gameObject.tag == "Breakable")
            {
                //add to multiplier
                GameManager.Instance.IncreaseScoreMultiplier();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collisionNormal"></param>
        private void Bounce(Vector3 collisionNormal)
        {
            
            var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);


            //Debug.Log("Out Direction: " + direction);
            Vector3 velocity = Vector3.zero;
            velocity.x = constantSpeed;
            velocity.y = constantSpeed;
            if (direction.x < 0)
            {
                velocity.x *= -1;
            }
            if (direction.y < 0)
            {
                velocity.y *= -1;
            }
            rb.velocity = velocity;
            //rb.velocity = direction * Mathf.Max(speed, minVelocity);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ResetBall()
        {
            active = false;
            rb.velocity = Vector3.zero;
            transform.position = player.transform.position + playerOffset;
            transform.parent = player.transform;
        }
    }

    
}
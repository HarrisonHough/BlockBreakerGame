using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BrickBreaker
{
    public class Ball : MonoBehaviour
    {
        public bool showVelocity;
        [SerializeField]
        private Paddle paddle;
        [SerializeField]
        private float startSpeed = 5f;

        private bool hasStarted = false;
        private Vector3 paddleToBallVector;
        private Rigidbody2D rb;

        private UIControl uiControl;

        // Use this for initialization
        void Start()
        {
            paddleToBallVector = transform.position - paddle.transform.position;
            rb = GetComponent<Rigidbody2D>();
            uiControl = FindObjectOfType<UIControl>();
        }


        private void Update()
        {
            if (!hasStarted)
            {
                transform.position = paddle.transform.position + paddleToBallVector;

                if (Input.GetMouseButton(0))
                {
                    uiControl.HideStartText();
                    rb.velocity = new Vector2(2f, 5f);
                    hasStarted = true;
                }
            }

            if (showVelocity)
            {
                Debug.Log("Velocity = " + rb.velocity);
            }
            
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Play bounce audio
            //if(collision.gameObject.tag == "Player")
            CheckVelocity();
            
            //Debug.Log("Ball Velocity = " + rb.velocity);
        }

        private void CheckVelocity()
        {           

            if (hasStarted)
            {
                Vector2 tweak = new Vector2(Random.Range(0, 0.2f), Random.Range(0, 0.2f));

                //tweak += Mathf.Clamp( rb.velocity, 0f ,of);
                if (Mathf.Abs(rb.velocity.x) < 0.2f)
                {
                    if (rb.velocity.x >= 0)
                    {
                        tweak.x = 1f;
                        
                    }
                    else
                    {
                        tweak.x = -1f;
                    }

                    tweak.x *= 5f;
                    Debug.Log("LOW Ball Velocity.x = " + rb.velocity.x);
                }
                if (Mathf.Abs(rb.velocity.y) < 2f)
                {
                    
                    //tweak.x = -1f;

                    tweak.y = -5f;
                    Debug.Log("LOW Ball Velocity.y = " + rb.velocity.y);
                }
                rb.velocity += tweak;
            }
        }

    }
}

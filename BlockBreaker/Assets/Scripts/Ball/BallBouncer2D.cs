using UnityEngine;

public class BallBouncer2D : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Just for debugging, adds some velocity during OnEnable")]
    private Vector3 initialVelocity;

    [SerializeField]
    private float constantSpeed = 10f;

    private Vector3 lastFrameVelocity;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartBallMovement();
    }

    public void StartBallMovement()
    {
        rb.velocity = initialVelocity;
    }

    private void Update()
    {
        lastFrameVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bounce(collision.contacts[0].normal);
    }

    private void Bounce(Vector3 collisionNormal)
    {
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        
        Debug.Log("Out Direction: " + direction);
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
}
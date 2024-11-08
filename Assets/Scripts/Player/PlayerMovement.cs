using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 maxSpeed;
    public Vector2 timeToFullSpeed;
    public Vector2 timeToStop;
    public Vector2 stopClamp;

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    // Define fixed boundaries for the player's movement
    private const float minX = -8.61f;
    private const float maxX = 8.61f;
    private const float minY = -5.07f;
    private const float maxY = 4.67f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        // Get input from user
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // Move only if there is input
        if (inputX != 0 || inputY != 0)
        {
            moveDirection = new Vector2(inputX, inputY).normalized;

            // Pastikan tidak ada pembagian dengan nol
            float moveVelocityX = (timeToFullSpeed.x != 0) ? 2 * maxSpeed.x / timeToFullSpeed.x : 0;
            float moveVelocityY = (timeToFullSpeed.y != 0) ? 2 * maxSpeed.y / timeToFullSpeed.y : 0;

            Vector2 newVelocity = rb.velocity;

            // Calculate new velocity and clamp to maxSpeed
            newVelocity.x = Mathf.Clamp(newVelocity.x + moveDirection.x * moveVelocityX * Time.fixedDeltaTime, -maxSpeed.x, maxSpeed.x);
            newVelocity.y = Mathf.Clamp(newVelocity.y + moveDirection.y * moveVelocityY * Time.fixedDeltaTime, -maxSpeed.y, maxSpeed.y);

            rb.velocity = newVelocity;
        }
        else
        {
            // If no input, stop the player
            rb.velocity = Vector2.zero;
        }

        // Clamp position based on the defined boundaries
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);

        transform.position = clampedPosition;
    }

    public bool IsMoving()
    {
        return rb.velocity.sqrMagnitude > stopClamp.sqrMagnitude;
    }

    private void FixedUpdate()
    {
        Move();
    }
}
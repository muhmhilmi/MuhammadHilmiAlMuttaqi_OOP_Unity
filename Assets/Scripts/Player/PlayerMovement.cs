using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 maxSpeed;
    public Vector2 timeToFullSpeed;
    public Vector2 timeToStop;
    public Vector2 stopClamp;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 moveVelocity;
    private Vector2 moveFriction;
    private Vector2 stopFriction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        moveDirection = new Vector2(inputX, inputY).normalized;

        float moveVelocityX = 2 * maxSpeed.x / timeToFullSpeed.x;
        float moveVelocityY = 2 * maxSpeed.y / timeToFullSpeed.y;
        float moveFrictionX = -2 * maxSpeed.x / Mathf.Pow(timeToStop.x, 2);
        float moveFrictionY = -2 * maxSpeed.y / Mathf.Pow(timeToStop.y, 2);
        float stopFrictionX = -2 * maxSpeed.x / Mathf.Pow(timeToStop.x, 2);
        float stopFrictionY = -2 * maxSpeed.y / Mathf.Pow(timeToStop.y, 2);

        Vector2 newVelocity = rb.velocity;
        
        newVelocity.x = Mathf.Clamp(newVelocity.x + moveDirection.x * moveVelocityX * Time.fixedDeltaTime, -maxSpeed.x, maxSpeed.x);
        newVelocity.y = Mathf.Clamp(newVelocity.y + moveDirection.y * moveVelocityY * Time.fixedDeltaTime, -maxSpeed.y, maxSpeed.y);

        rb.velocity = newVelocity;
    }

    public bool IsMoving()
    {
        return rb.velocity.sqrMagnitude > stopClamp.sqrMagnitude;
    }
}
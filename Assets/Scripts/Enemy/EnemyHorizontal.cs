using UnityEngine;

public class EnemyHorizontal : Enemy
{
    private bool movingRight;

    protected override void Start()
    {
        base.Start();
        // Randomly decide if the enemy moves right or left
        movingRight = Random.value > 0.5f;
    }

    protected override void Update()
    {
        base.Update();

        // Move horizontally based on direction
        Vector3 direction = movingRight ? Vector3.right : Vector3.left;
        transform.Translate(direction * speed * Time.deltaTime);

        // Change direction if out of screen bounds
        if (transform.position.x > 10f) // Misalnya batas kanan layar
        {
            movingRight = false;
        }
        else if (transform.position.x < -10f) // Misalnya batas kiri layar
        {
            movingRight = true;
        }
    }
}

using UnityEngine;

public class EnemyForwardMovement : Enemy
{
    protected override void Move()
    {
        // Gerakan ke bawah
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Jika keluar layar, respawn di posisi acak
        if (Camera.main.WorldToViewportPoint(transform.position).y < -0.05f)
        {
            PickRandomPosition();
        }
    }

    private void PickRandomPosition()
    {
        Vector2 randPos = new Vector2(Random.Range(0.1f, 0.9f), 1.1f); // Spawn di atas layar
        transform.position = Camera.main.ViewportToWorldPoint(randPos) + Vector3.forward * 10;
    }
}

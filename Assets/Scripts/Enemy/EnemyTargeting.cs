using UnityEngine;

public class EnemyTargeting : Enemy
{
    protected override void Update()
    {
        base.Update();

        // Check if player reference exists
        if (player != null)
        {
            // Move towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}

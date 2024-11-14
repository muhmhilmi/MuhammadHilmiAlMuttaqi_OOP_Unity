using UnityEngine;

public class EnemyForward : Enemy
{
    protected override void Update()
    {
        base.Update();
        // Move downward at a fixed speed
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}

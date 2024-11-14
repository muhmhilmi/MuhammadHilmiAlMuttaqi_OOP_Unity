using UnityEngine;

public class EnemyBoss : Enemy
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float shootInterval = 3f;

    private float shootTimer;

    protected override void Update()
    {
        base.Update();
        // Boss moves down slowly
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Shooting mechanism
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0;
        }
    }

    private void Shoot()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }
}

using UnityEngine;

public class EnemyBoss : Enemy
{
    [Header("Boss Weapon")]
    public GameObject bulletPrefab;         // Prefab peluru
    public Transform[] bulletSpawnPoints;   // Posisi spawn peluru
    public float shootInterval = 1.5f;      // Interval menembak
    private float shootTimer;               // Timer untuk menembak

    [Header("Boss Movement")]
    public float movementRange = 5f;       // Rentang gerakan horizontal
    private bool movingRight = true;       // Arah gerakan
    private Vector3 startPosition;         // Posisi awal

    protected override void Start()
    {
        base.Start();
        startPosition = transform.position; // Simpan posisi awal
    }

    protected override void Update()
    {
        base.Update();
        HandleShooting();
    }

    protected override void Move()
    {
        // Gerakan bolak-balik secara horizontal
        float direction = movingRight ? 1 : -1;
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        // Balik arah jika mencapai batas
        if (transform.position.x > startPosition.x + movementRange)
        {
            movingRight = false;
        }
        else if (transform.position.x < startPosition.x - movementRange)
        {
            movingRight = true;
        }
    }

    private void HandleShooting()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0;
        }
    }

    private void Shoot()
    {
        foreach (Transform spawnPoint in bulletSpawnPoints)
        {
            Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}

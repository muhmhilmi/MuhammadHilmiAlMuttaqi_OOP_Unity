using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Spawner Settings")]
    public GameObject enemyPrefab;         // Prefab musuh
    public Transform[] spawnPoints;        // Posisi spawn musuh
    public float spawnInterval = 3f;       // Interval waktu spawn
    public int spawnCount = 1;             // Jumlah musuh di setiap spawn

    private float spawnTimer = 0;          // Timer untuk spawn musuh

    void Update()
    {
        // Hitung waktu untuk spawn
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemies();                // Spawn musuh
            spawnTimer = 0;                // Reset timer
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            // Pilih posisi spawn secara acak
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}

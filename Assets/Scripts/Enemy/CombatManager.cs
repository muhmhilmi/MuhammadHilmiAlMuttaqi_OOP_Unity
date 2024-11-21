using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [Header("Wave System Settings")]
    public EnemySpawner[] enemySpawners;  // Daftar semua spawner musuh
    public float waveInterval = 10f;      // Waktu antar wave
    public int waveNumber = 1;            // Nomor wave saat ini

    private float waveTimer = 0;          // Timer untuk wave

    void Update()
    {
        // Hitung waktu untuk wave berikutnya
        waveTimer += Time.deltaTime;
        if (waveTimer >= waveInterval)
        {
            StartNextWave();              // Mulai wave baru
            waveTimer = 0;                // Reset timer
        }
    }

    void StartNextWave()
    {
        waveNumber++;                     // Tingkatkan nomor wave
        Debug.Log("Wave " + waveNumber);

        foreach (EnemySpawner spawner in enemySpawners)
        {
            spawner.spawnCount += 1;      // Tambah jumlah musuh per wave
            spawner.spawnInterval = Mathf.Max(1f, spawner.spawnInterval - 0.5f); // Kurangi interval spawn
        }
    }
}

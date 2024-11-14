using System.Collections;
using UnityEngine;
using UnityEngine.Pool; // Untuk Object Pooling

public class Weapon : MonoBehaviour
{
    public Transform parentTransform;

    [Header("Weapon Settings")]
    public GameObject bulletPrefab;           // Prefab Bullet yang akan ditembakkan
    public Transform bulletSpawnPoint;        // Posisi tempat Bullet muncul
    public float shootIntervalInSeconds = 0.00005f; // Waktu jeda antar tembakan

    private float timer = 0f; // Timer untuk menghitung jeda antar tembakan

    // Object Pool untuk peluru
    private IObjectPool<GameObject> bulletPool;

    private void Awake()
    {
        // Inisialisasi Object Pool dengan konfigurasi
        bulletPool = new ObjectPool<GameObject>(
            CreateBullet,           // Fungsi untuk membuat Bullet baru
            OnGetFromPool,          // Fungsi saat mengambil Bullet dari pool
            OnReleaseToPool,        // Fungsi saat mengembalikan Bullet ke pool
            OnDestroyBullet,        // Fungsi saat menghancurkan Bullet
            false,                  // Tidak melakukan collection check
            10,                     // Kapasitas awal
            50                      // Kapasitas maksimal
        );
    }

    private GameObject CreateBullet()
    {
        // Membuat bullet baru dari prefab dan menonaktifkannya
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.SetActive(false); // Menonaktifkan bullet untuk tidak muncul di scene
        return bullet;
    }

    private void OnGetFromPool(GameObject bullet)
    {
        // Mengaktifkan bullet saat diambil dari pool dan mengatur posisi serta rotasi
        bullet.transform.position = bulletSpawnPoint.position; // Posisi diambil dari BulletSpawnPoint
        bullet.transform.rotation = bulletSpawnPoint.rotation; // Rotasi diambil dari BulletSpawnPoint
        bullet.SetActive(true); // Mengaktifkan bullet

        // Ambil komponen Rigidbody2D untuk memberi kecepatan pada bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Memberikan kecepatan peluru sesuai arah yang ditunjukkan oleh BulletSpawnPoint
            rb.velocity = bullet.transform.up * 20f; // Anda bisa sesuaikan kecepatan peluru
        }
    }

    private void OnReleaseToPool(GameObject bullet)
    {
        // Menonaktifkan bullet saat dikembalikan ke pool
        bullet.SetActive(false);
    }

    private void OnDestroyBullet(GameObject bullet)
    {
        // Menghancurkan bullet saat pool mencapai kapasitas maksimal
        Destroy(bullet);
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Mengecek apakah sudah waktunya untuk menembak
        if (timer >= shootIntervalInSeconds)
        {
            Shoot(); // Memanggil fungsi Shoot
            timer = 0; // Reset timer setelah menembak
        }
    }

    private void Shoot()
    {
        if (bulletPool != null)
        {
            // Mengambil peluru dari pool dan menembakkannya
            bulletPool.Get();
        }
    }

    public void ReturnBulletToPool(GameObject bullet)
    {
        // Mengembalikan bullet ke pool setelah digunakan
        bulletPool.Release(bullet);
    }
}

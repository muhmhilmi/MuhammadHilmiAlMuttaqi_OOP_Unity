using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20f;        // Kecepatan peluru
    public int damage = 10;               // Damage yang diberikan peluru

    private Rigidbody2D rb;               // Referensi ke Rigidbody2D
    public IObjectPool<Bullet> objectPool; // Pooling untuk mengelola peluru

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Assert.IsNotNull(rb, "Rigidbody2D harus ada pada objek Bullet!"); // Validasi
    }

    private void OnEnable()
    {
        // Ketika bullet diaktifkan, atur velocity
        if (rb != null)
        {
            rb.velocity = transform.up * bulletSpeed; // Peluru bergerak ke atas
        }
    }

    private void Update()
    {
        // Periksa apakah peluru keluar dari layar
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPosition.y > 1.01f || viewportPosition.y < -0.01f || viewportPosition.x > 1.01f || viewportPosition.x < -0.01f)
        {
            // Kembalikan peluru ke pool jika keluar layar
            ReleaseBullet();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Jika peluru mengenai Enemy
        if (other.CompareTag("Enemy"))
        {
            // Ambil HitboxComponent pada Enemy dan berikan damage
            var hitbox = other.GetComponent<HitboxComponent>();
            if (hitbox != null)
            {
                hitbox.Damage(this); // Damage menggunakan peluru ini
            }

            // Kembalikan peluru ke pool setelah tabrakan
            ReleaseBullet();
        }
        else if (other.CompareTag("Wall")) // Opsional: Jika peluru mengenai tembok
        {
            ReleaseBullet();
        }
    }

    private void ReleaseBullet()
    {
        // Kembalikan peluru ke pool hanya jika objectPool tidak null
        if (objectPool != null)
        {
            objectPool.Release(this);
        }
        else
        {
            // Jika tidak ada pooling, hancurkan peluru
            Destroy(gameObject);
        }
    }
}

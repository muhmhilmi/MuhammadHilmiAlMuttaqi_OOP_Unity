using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f; // Kecepatan peluru
    public int damage = 10;   // Damage yang diberikan peluru

    private Rigidbody2D rb;
    private Weapon weapon;    // Referensi ke Weapon untuk mengembalikan Bullet ke pool

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        rb.gravityScale = 0f; // Tidak terpengaruh gravitasi
    }

    void OnEnable()
    {
        // Saat bullet diaktifkan, tentukan arah dan kecepatan
        rb.velocity = transform.up * speed; // Menggunakan arah BulletSpawnPoint untuk bergerak
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Bullet hit an enemy!");

            // Optional: Mengurangi health Enemy jika ada script HealthComponent
            // Enemy enemy = other.GetComponent<Enemy>();
            // if (enemy != null)
            // {
            //     enemy.TakeDamage(damage);
            // }

            // Mengembalikan Bullet ke pool
            if (weapon != null)
            {
                weapon.ReturnBulletToPool(gameObject);
            }
        }
    }

    void OnBecameInvisible()
    {
        // Mengembalikan Bullet ke pool ketika keluar dari layar
        if (weapon != null)
        {
            weapon.ReturnBulletToPool(gameObject);
        }
    }
}

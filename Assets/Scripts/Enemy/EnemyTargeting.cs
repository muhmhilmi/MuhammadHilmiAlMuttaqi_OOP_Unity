using UnityEngine;

public class EnemyTargetPlayer : Enemy
{
    private Transform player; // Referensi ke pemain (Player)
    private Rigidbody2D rb;   // Rigidbody2D untuk pergerakan

    protected override void Start()
    {
        base.Start();

        // Cari objek pemain berdasarkan Tag
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        // Ambil komponen Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Debug log untuk memastikan player ditemukan
        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the Player object has the correct Tag.");
        }

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found! Make sure the enemy has a Rigidbody2D component.");
        }
    }

    protected override void Move()
    {
        // Pastikan player ada di scene
        if (player != null)
        {
            // Hitung arah menuju posisi pemain
            Vector2 direction = (player.position - transform.position).normalized;

            // Pergerakan musuh menggunakan Rigidbody2D
            rb.velocity = direction * speed;
        }
        else
        {
            // Jika player tidak ditemukan, hentikan pergerakan
            rb.velocity = Vector2.zero;
        }
    }
}

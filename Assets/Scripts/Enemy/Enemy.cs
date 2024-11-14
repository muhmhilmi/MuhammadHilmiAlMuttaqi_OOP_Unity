using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int level = 1; // Level enemy yang bisa diatur
    public float speed = 2f; // Kecepatan dasar untuk pergerakan musuh

    // Method untuk mengambil referensi Player (bisa digunakan pada Enemy Targeting)
    protected Transform player;

    protected virtual void Start()
    {
        // Mencari Player di scene berdasarkan tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    protected virtual void Update()
    {
        // Perilaku dasar dapat diatur di subclass
    }

    // Method yang bisa ditambahkan di setiap musuh untuk memberikan damage atau interaksi lain
    public virtual void TakeDamage(int damage)
    {
        // Logika ketika enemy menerima damage
        Debug.Log($"{gameObject.name} took {damage} damage.");
        Destroy(gameObject); // Hancurkan enemy setelah menerima damage, atau kurangi health jika ada
    }
}

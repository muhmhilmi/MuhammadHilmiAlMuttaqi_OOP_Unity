using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;  // Nilai health maksimum
    public int health;           // Nilai health saat ini

    // Getter untuk health
    public int Health
    {
        get { return health; }
    }

    // Setter untuk mengurangi health
    public void Subtract(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);  // Hancurkan objek jika health <= 0
        }
    }

    // Initialize health saat entitas pertama kali muncul
    void Start()
    {
        health = maxHealth; // Set health ke nilai maksimum saat start
    }
}

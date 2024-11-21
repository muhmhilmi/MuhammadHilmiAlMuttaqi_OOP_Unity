using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float speed = 2f;          // Kecepatan gerakan musuh
    public int maxHealth = 50;        // Health maksimum musuh
    private int currentHealth;        // Health saat ini

    [Header("Events")]
    public UnityEvent enemyKilledEvent; // Event saat musuh mati

    protected virtual void Start()
    {
        currentHealth = maxHealth;     // Inisialisasi health
        enemyKilledEvent ??= new UnityEvent();
    }

    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        // Default gerakan: ke bawah
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        enemyKilledEvent.Invoke(); // Panggil event
        Destroy(gameObject);       // Hancurkan musuh
    }
}

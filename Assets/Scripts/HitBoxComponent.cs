using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    private HealthComponent healthComponent;  // Referensi ke HealthComponent

    void Start()
    {
        // Menemukan HealthComponent pada objek yang sama
        healthComponent = GetComponent<HealthComponent>();
        if (healthComponent == null)
        {
            Debug.LogError("HealthComponent tidak ditemukan pada objek ini.");
        }
    }

    // Fungsi untuk menerima damage
    public void Damage(int damage)
    {
        if (healthComponent != null)
        {
            healthComponent.Subtract(damage);  // Mengurangi health berdasarkan damage
        }
    }

    // Overloading Damage untuk menerima Bullet
    public void Damage(Bullet bullet)
    {
        // Mengurangi health berdasarkan damage dari Bullet
        if (healthComponent != null)
        {
            healthComponent.Subtract(bullet.damage);
        }
    }
}

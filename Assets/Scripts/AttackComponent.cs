using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackComponent : MonoBehaviour
{
    public int damage = 10; // Damage serangan

    void OnTriggerEnter2D(Collider2D other)
    {
        // Mengecek apakah objek yang terkena adalah HitboxComponent dan bukan objek yang sama
        HitboxComponent hitbox = other.GetComponent<HitboxComponent>();
        if (hitbox != null)
        {
            // Kirim damage ke Hitbox
            hitbox.Damage(damage);
        }
    }
}

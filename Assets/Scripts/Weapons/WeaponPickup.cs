using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder; // Pastikan untuk meng-assign Weapon prefab di Inspector
    private Weapon weapon;

    private void Awake()
    {
        // Memastikan weaponHolder sudah di-assign di Inspector
        if (weaponHolder != null)
        {
            // Menginisialisasi weapon dari weaponHolder untuk digunakan saat pickup
            weapon = weaponHolder;
            Debug.Log("Weapon successfully assigned from weaponHolder: " + weapon.name);
        }
        else
        {
            Debug.LogError("WeaponHolder is not assigned in the Inspector. Please assign it.");
        }
    }

    private void Start()
    {
        // Memastikan visual weapon dinonaktifkan pada awalnya
        if (weapon != null)
        {
            TurnVisual(false);
            Debug.Log("Weapon visuals are initially turned off.");
        }
        else
        {
            Debug.LogWarning("Weapon is null in Start. Please check if weaponHolder is assigned correctly.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D called with: " + other.name);
        
        if (weapon == null)
        {
            Debug.LogWarning("Weapon is still null on trigger. Please check weaponHolder assignment.");
            return;
        }

        // Cek apakah objek yang bersentuhan memiliki tag "Player"
        if (other.CompareTag("Player"))
        {
            // Set parent weapon ke Player untuk membuatnya menjadi bagian dari Player
            weapon.transform.SetParent(other.transform);
            
            // Aktifkan visual weapon dan collider saat diambil
            TurnVisual(true);

            Debug.Log("Weapon picked up and assigned to Player: " + weapon.name);
            
            // Hapus komponen Collider2D pada WeaponPickup setelah diambil,
            // agar tidak bisa diambil lagi
            Destroy(GetComponent<Collider2D>());
        }
    }

    // Method untuk mengatur visual weapon saat diambil atau tidak
    private void TurnVisual(bool state)
    {
        if (weapon != null)
        {
            Renderer renderer = weapon.GetComponentInChildren<Renderer>(true);
            Collider2D collider = weapon.GetComponentInChildren<Collider2D>(true);

            if (renderer != null)
            {
                renderer.enabled = state;
                Debug.Log("Renderer set to " + state);
            }
            else
            {
                Debug.LogWarning("Renderer component not found on the weapon.");
            }

            if (collider != null)
            {
                collider.enabled = state;
                Debug.Log("Collider set to " + state);
            }
            else
            {
                Debug.LogWarning("Collider component not found on the weapon.");
            }
        }
        else
        {
            Debug.LogWarning("Weapon is null when trying to toggle visuals.");
        }
    }
}

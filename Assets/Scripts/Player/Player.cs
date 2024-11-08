using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator animator;

    public static Player Instance { get; private set; }

    // Tambahkan properti HasWeapon
    public bool HasWeapon { get; private set; }

    private void Awake()
    {
        // Singleton pattern untuk memastikan hanya ada satu instance Player
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Menjaga Player tetap ada di seluruh scene
        }
        else
        {
            Destroy(gameObject); // Menghancurkan duplikat Player
        }
    }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        // Inisialisasi animator
        animator = transform.Find("Engine/EngineEffect")?.GetComponent<Animator>();
        
        // Log error jika animator tidak ditemukan
        if (animator == null)
        {
            Debug.LogError("Animator tidak ditemukan! Pastikan 'Engine/EngineEffect' memiliki komponen Animator.");
        }
    }

    private void FixedUpdate()
    {
        // Memastikan Player dapat bergerak
        if (playerMovement != null)
        {
            playerMovement.Move();
        }
    }

    private void LateUpdate()
    {
        // Pengecekan null untuk menghindari error jika animator hilang
        if (animator != null)
        {
            bool isMoving = playerMovement != null && playerMovement.IsMoving();
            animator.SetBool("IsMoving", isMoving);
        }
    }

    // Tambahkan metode untuk mengubah status HasWeapon
    public void EquipWeapon()
    {
        HasWeapon = true;
    }

    public void UnequipWeapon()
    {
        HasWeapon = false;
    }
}

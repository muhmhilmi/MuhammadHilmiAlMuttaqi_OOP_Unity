using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator animator;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static Player Instance { get; private set; }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();        
        animator = transform.Find("Engine/EngineEffect").GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        playerMovement.Move();
    }

    private void LateUpdate()
    {
        bool isMoving = playerMovement.IsMoving();
        animator.SetBool("IsMoving", isMoving);
    }
}

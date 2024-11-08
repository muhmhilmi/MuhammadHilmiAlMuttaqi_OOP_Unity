using UnityEngine;

public class Portal : MonoBehaviour
{
    public float speed = 5f;
    public float rotatespeed = 100f;
    private Vector3 newPosition;

    void Start()
    {
        ChangePosition();
    }

    void ChangePosition()
    {
        newPosition = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, newPosition) < 0.5f)
        {
            ChangePosition();
        }

        // Mengakses Player.Instance.HasWeapon
        if (Player.Instance != null && Player.Instance.HasWeapon)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }

        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        transform.Rotate(Vector3.forward * rotatespeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelManager.Instance.LoadScene("Main");
        }
    }
}

using UnityEngine;

public class EnemyHorizontalMovement : Enemy
{
    private float direction = 1f; // Arah gerakan horizontal (1 = kanan, -1 = kiri)

    [Header("Horizontal Movement Settings")]
    public float boundaryOffset = 3f; // Jarak batas kiri dan kanan dari posisi awal

    private float leftBoundary;  // Batas kiri gerakan
    private float rightBoundary; // Batas kanan gerakan
    private float initialY;      // Posisi awal pada sumbu Y

    protected override void Start()
    {
        base.Start();

        // Simpan posisi awal Y untuk memastikan tidak berubah
        initialY = transform.position.y;

        // Tetapkan batas kiri dan kanan berdasarkan posisi awal
        leftBoundary = transform.position.x - boundaryOffset;
        rightBoundary = transform.position.x + boundaryOffset;
    }

    protected override void Move()
    {
        // Gerakan horizontal pada sumbu X
        transform.position += Vector3.right * direction * speed * Time.deltaTime;

        // Jika mencapai batas kiri atau kanan, ubah arah
        if (transform.position.x > rightBoundary)
        {
            direction = -1f; // Bergerak ke kiri
        }
        else if (transform.position.x < leftBoundary)
        {
            direction = 1f; // Bergerak ke kanan
        }

        // Pastikan posisi Y tetap sama (tidak berubah karena glitch atau bug)
        transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
    }
}

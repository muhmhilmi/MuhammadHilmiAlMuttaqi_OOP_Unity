using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseWeaponUI : MonoBehaviour
{
    public Text titleText;  // Teks judul
    public Button weaponButton1;  // Tombol untuk senjata 1
    public Button weaponButton2;  // Tombol untuk senjata 2
    public Button weaponButton3;  // Tombol untuk senjata 3

    // Fungsi untuk memilih senjata
    private void Start()
    {
        // Menambahkan fungsi ketika tombol diklik
        weaponButton1.onClick.AddListener(() => ChooseWeapon(1));
        weaponButton2.onClick.AddListener(() => ChooseWeapon(2));
        weaponButton3.onClick.AddListener(() => ChooseWeapon(3));
    }

    private void ChooseWeapon(int weaponIndex)
    {
        // Lakukan sesuatu berdasarkan senjata yang dipilih
        Debug.Log("Senjata yang dipilih: " + weaponIndex);

        // Misalnya, pindah ke scene berikutnya setelah memilih senjata
        SceneManager.LoadScene("Main");
    }
}

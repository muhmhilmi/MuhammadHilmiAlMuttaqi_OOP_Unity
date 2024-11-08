using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Menambahkan namespace ini untuk mendukung IEnumerator

public class LevelManager : MonoBehaviour
{
    // Instance untuk singleton
    public static LevelManager Instance { get; private set; }

    private void Awake()
    {
        // Pastikan hanya ada satu instance LevelManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Membuat LevelManager tetap ada saat scene berubah
        }
        else
        {
            Destroy(gameObject); // Menghapus duplikat LevelManager
        }
    }

    public void LoadScene(string sceneName)
    {
        // Memulai proses untuk load scene
        StartCoroutine(TransitionToScene(sceneName));
    }

    private IEnumerator TransitionToScene(string sceneName)
    {
        // Menambahkan waktu tunggu atau animasi transisi di sini jika diperlukan
        yield return new WaitForSeconds(1); // Sesuaikan durasi animasi transisi
        SceneManager.LoadScene(sceneName);
    }
}

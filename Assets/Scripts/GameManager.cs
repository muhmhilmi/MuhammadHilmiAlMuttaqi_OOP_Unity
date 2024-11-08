using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton untuk mengakses GameManager dari mana saja

    void Awake()
    {
        // Implementasi Singleton Pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        RemoveAllObjectsExceptCameraAndPlayer();
    }

    // Fungsi untuk menghilangkan semua objek kecuali Camera dan Player
    void RemoveAllObjectsExceptCameraAndPlayer()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.tag != "MainCamera" && obj.tag != "Player")
            {
                Destroy(obj);
            }
        }
    }
}

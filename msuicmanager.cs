using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; } // Singleton Instance

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Assign this instance
            DontDestroyOnLoad(gameObject); // Make it persistent
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate
        }
    }
}

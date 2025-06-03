using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // Singleton eriþimi

    public int currentLevel = 1;

    void Awake()
    {
        // Singleton kontrolü
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Sahne deðiþse bile kaybolmaz
        }
        else
        {
            Destroy(gameObject); // Ýkinci kopyayý yok et
        }
    }
}

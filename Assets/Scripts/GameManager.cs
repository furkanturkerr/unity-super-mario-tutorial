using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // Singleton eri�imi

    public int currentLevel = 1;

    void Awake()
    {
        // Singleton kontrol�
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Sahne de�i�se bile kaybolmaz
        }
        else
        {
            Destroy(gameObject); // �kinci kopyay� yok et
        }
    }
}

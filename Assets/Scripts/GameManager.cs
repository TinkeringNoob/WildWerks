using UnityEngine;

// Manages overall game state and functionality
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton instance

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this method to pause the game
    public void PauseGame()
    {
        Time.timeScale = 0f; // Pauses the game
        Debug.Log("Game Paused");
    }

    // Call this method to resume the game
    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resumes the game
        Debug.Log("Game Resumed");
    }
}

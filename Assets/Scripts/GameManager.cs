using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Provides global access to the singleton instance of the GameManager.
    /// </summary>
    public static GameManager Instance { get; private set; }

    public LevelManager levelManager;

    /// <summary>
    /// Initializes the GameManager instance and ensures it persists across scene loads.
    /// Destroys duplicate instances to maintain a single GameManager.
    /// </summary>
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

    /// <summary>
    /// Starts the game by initializing the level through the LevelManager.
    /// </summary>
    private void Start()
    {
        levelManager.InitializeLevel();
    }
}

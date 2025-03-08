using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Provides global access to the singleton instance of the GameManager.
    /// </summary>
    public static GameManager Instance { get; private set; }

    public LevelManager levelManagerPrefab;

    private LevelManager _levelManager;

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

        InitializeManagers();
    }

    /// <summary>
    /// Initializes and instantiates the LevelManager from a prefab.
    /// Sets the LevelManager as a child of the GameManager.
    /// </summary>
    private void InitializeManagers()
    {
        _levelManager = Instantiate(levelManagerPrefab);
        _levelManager.transform.SetParent(transform);
    }

    /// <summary>
    /// Starts the game by initializing the level through the LevelManager.
    /// </summary>
    private void Start()
    {
        _levelManager.InitializeLevel();
    }
}

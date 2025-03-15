using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject platformsPrefab;
    public GameObject bordersPrefab;

    /// <summary>
    /// Initializes the level by instantiating the player and platforms at their respective positions.
    /// </summary>
    public void InitializeLevel()
    {
        Instantiate(platformsPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(bordersPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}

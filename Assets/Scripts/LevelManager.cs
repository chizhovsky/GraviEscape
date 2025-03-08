using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject platformsPrefab;

    /// <summary>
    /// Initializes the level by instantiating the player and platforms at their respective positions.
    /// </summary>
    public void InitializeLevel()
    {
        Instantiate(playerPrefab, new Vector3(-0.2329f, -1.44f, 0), Quaternion.identity);
        Instantiate(platformsPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}

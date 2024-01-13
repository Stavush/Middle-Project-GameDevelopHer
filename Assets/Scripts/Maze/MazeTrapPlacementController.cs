using UnityEngine;

public class MazeTrapPlacementController : MonoBehaviour
{
    // Singleton instance
    public static MazeTrapPlacementController Instance;

    public MazeTrapPlacementModel mazetrapPlacementModel;

    void Awake()
    {
        // Singleton to ensure there is only one instance
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

    void Start()
    {
        // Place traps and the Queen enemy when the game starts
        PlaceTraps();
        PlaceQueenEnemy();
    }

    void PlaceTraps()
    {
        for (int i = 0; i < mazetrapPlacementModel.numberOfTraps; i++)
        {
            Vector3Int trapPosition = mazetrapPlacementModel.GetRandomTrapPosition();
            PlaceTrapAtPosition(trapPosition);
        }
    }

    void PlaceTrapAtPosition(Vector3Int position)
    {
        GameObject selectedTrapPrefab = mazetrapPlacementModel.GetRandomTrapPrefab();
        if (selectedTrapPrefab != null)
        {
            // Instantiate the trap prefab at the specified position
            Instantiate(selectedTrapPrefab, mazetrapPlacementModel.trapTilemap.GetCellCenterWorld(position), Quaternion.identity);
        }
        else
        {
            Debug.LogError("Failed to get a random trap prefab!");
        }
    }

        void PlaceQueenEnemy()
    {
        // Place the Queen enemy at the exit point
        Vector3Int exitPosition = mazetrapPlacementModel.GetRandomTrapPosition(); // Example, adjust as needed
        Instantiate(mazetrapPlacementModel.queenEnemyPrefab, mazetrapPlacementModel.trapTilemap.GetCellCenterWorld(exitPosition), Quaternion.identity);
    }
}
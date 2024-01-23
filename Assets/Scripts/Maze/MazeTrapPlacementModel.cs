using UnityEngine;
using UnityEngine.Tilemaps;

public class MazeTrapPlacementModel : MonoBehaviour
{
    // Reference to the trap tilemap
    public Tilemap trapTilemap;

    // Array of trap prefabs
    public GameObject[] trapPrefabs;

    // Enemy prefab for the Queen
    public GameObject queenEnemyPrefab;

    public int numberOfTraps = 3;

    public Vector3Int GetRandomTrapPosition()
    {
        // You can implement logic to get a random position within the trapTilemap bounds
        int randomX = Random.Range(trapTilemap.cellBounds.x, trapTilemap.cellBounds.x + trapTilemap.cellBounds.size.x);
        int randomY = Random.Range(trapTilemap.cellBounds.y, trapTilemap.cellBounds.y + trapTilemap.cellBounds.size.y);

        return new Vector3Int(randomX, randomY, 0);
    }

    public GameObject GetRandomTrapPrefab()
    {
        // Ensure there are trap prefabs available
        if (trapPrefabs == null || trapPrefabs.Length == 0)
        {
            Debug.LogError("No trap prefabs assigned!");
            return null;
        }

        // Get a random index to select a random trap prefab
        int randomIndex = Random.Range(0, trapPrefabs.Length);

        // Return the selected trap prefab
        return trapPrefabs[randomIndex];
    }
}
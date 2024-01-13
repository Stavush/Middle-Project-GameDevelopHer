using UnityEngine;
using UnityEngine.Tilemaps;

public class TrapMazePlacementModel : MonoBehaviour
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
}
using UnityEngine;
using UnityEngine.Tilemaps;

public class MazeController : MonoBehaviour
{
    public Tilemap mazeTilemap;
    public TileBase wallTile;
    public TileBase passageTile;
    public TileBase exitTile;

    public MazeModel mazeModel;
    public Transform player;

    private Vector3Int exitPosition;

    void Start()
    {
        GenerateMaze();
        PlacePlayerAtStartPosition();
        PlaceExit();
    }

    void GenerateMaze()
    {
        // Initialize the maze with walls
        for (int x = 0; x < mazeModel.mazeWidth; x++)
        {
            for (int y = 0; y < mazeModel.mazeHeight; y++)
            {
                mazeTilemap.SetTile(new Vector3Int(x, y, 0), wallTile);
            }
        }

        // You can replace the maze generation logic here if needed
    }

    void PlacePlayerAtStartPosition()
    {
        player.position = new Vector3(mazeModel.startPositionX, mazeModel.startPositionY);
    }

    void PlaceExit()
    {
        mazeTilemap.SetTile(mazeModel.ExitPosition, exitTile);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player reached the exit
        if (other.transform == player)
        {
            Debug.Log("Player reached the exit!");
        }
    }
}
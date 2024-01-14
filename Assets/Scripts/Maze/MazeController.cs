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
    private float startTime;

    void Start()
    {
        GenerateMaze();
        PlacePlayerAtStartPosition();
        PlaceExit();

        // Record the start time when the game begins
        startTime = Time.time;
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
        exitPosition = mazeModel.ExitPosition;
        mazeTilemap.SetTile(exitPosition, exitTile);
    }

    void Update()
    {
        // Check for winning conditions
        CheckWinningCondition();

        // Check for losing conditions
        CheckLosingCondition();
    }

    void CheckWinningCondition()
    {
        // Check if the player is close to the exit point
        float distanceToExit = Vector3.Distance(player.position, mazeTilemap.GetCellCenterWorld(exitPosition));

        // You can adjust the threshold distance as needed
        float winningDistanceThreshold = 1.0f;

        if (distanceToExit < winningDistanceThreshold)
        {
            Debug.Log("Player reached the exit! You win!");
 
        }
    }

    void CheckLosingCondition()
    {
        // Check if the player has played for 2 minutes without reaching the exit
        float elapsedTime = Time.time - startTime;
        float losingTimeThreshold = 120.0f; // 2 minutes in seconds

        if (elapsedTime > losingTimeThreshold)
        {
            Debug.Log("You took too long! You lose.");
          
        }
    }
}
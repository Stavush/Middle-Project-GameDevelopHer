using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

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
    private float countdownDuration = 120.0f; // 2 minutes in seconds

    public Text countdownText;
    public GameObject losePopup;
    public GameObject winPopup;

    void Start()
    {
        GenerateMaze();
        PlacePlayerAtStartPosition();
        PlaceExit();

        // Record the start time when the game begins
        startTime = Time.time;

        // Initialize UI elements
        UpdateCountdownUI();
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
            winPopup.SetActive(true);

        }           
    }

    void CheckLosingCondition()
    {

        float elapsedTime = Time.time - startTime;
        float remainingTime = Mathf.Max(countdownDuration - elapsedTime, 0.0f);

    
        UpdateCountdownUI();

        // Check if the countdown has reached 00:00
        if (remainingTime <= 0.0f)
        {
            Debug.Log("Time's up! You lose.");
         

            // Show the lose popup
            losePopup.SetActive(true);
        }
    }

    void UpdateCountdownUI()
    {
        // Format the remaining time as minutes:seconds
        int minutes = Mathf.FloorToInt(countdownDuration / 60.0f);
        int seconds = Mathf.FloorToInt(countdownDuration % 60.0f);
        string countdownString = string.Format("{0:00}:{1:00}", minutes, seconds);


        countdownText.text = countdownString;
    }
}
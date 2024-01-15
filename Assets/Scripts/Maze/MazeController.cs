using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MazeController : MonoBehaviour
{

    //   public TileBase exitTile;

    public MazeModel mazeModel;
    public Transform player;
    public Tilemap mazeTilemap;
    public TileBase wallTile;
    public TileBase passageTile;
    public TileBase exitTile;

    private Vector3Int exitPosition;
    private float startTime;
    private float countdownDuration = 120.0f; // 2 minutes in seconds
    float remainingTime;

    [SerializeField]
    public TMP_Text countdownText;
    public GameObject losePopup;
    public GameObject winPopup;

    void Start()
    {

        PlacePlayerAtStartPosition();
        PlaceExit();


        startTime = Time.time;
        losePopup.SetActive(false);
        winPopup.SetActive(false);


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


        CheckWinningCondition();



        CheckLosingCondition();
    }

    void CheckWinningCondition()
    {
        // Check if the player is close to the exit point
        float distanceToExit = Vector3.Distance(player.position, mazeTilemap.GetCellCenterWorld(exitPosition));


        float winningDistanceThreshold = 1.0f;

        if (distanceToExit < winningDistanceThreshold)
        {

            winPopup.SetActive(true);

        }
    }

    void CheckLosingCondition()
    {

        float elapsedTime = Time.time - startTime;
        remainingTime = Mathf.Max(countdownDuration - elapsedTime, 0.0f);



        UpdateCountdownUI();

        // Check if the countdown has reached 00:00
        if (remainingTime <= 0.0f)
        {
            Debug.Log("Time's up! You lose.");



            losePopup.SetActive(true);
        }
    }

    void UpdateCountdownUI()
    {

        int minutes = Mathf.FloorToInt(remainingTime / 60.0f);
        int seconds = Mathf.FloorToInt(remainingTime % 60.0f);
        string countdownString = string.Format("{0:00}:{1:00}", minutes, seconds);


        countdownText.SetText(countdownString);
    }
}
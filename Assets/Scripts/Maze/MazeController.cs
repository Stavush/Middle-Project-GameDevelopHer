using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MazeController : MonoBehaviour
{


  
    private float startTime;
    private float countdownDuration = 120.0f; // 2 minutes in seconds
    float remainingTime;

    [SerializeField]
    public TMP_Text countdownText;
    public GameObject losePopup;
    public GameObject winPopup;

    void Start()
    {

        startTime = Time.time;
        losePopup.SetActive(false);
        winPopup.SetActive(false);

    }




    void Update()
    {


      



        CheckLosingCondition();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering collider belongs to Alice
        if (other.CompareTag("Player"))
        {
            // Alice entered the finish line, trigger winning condition
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
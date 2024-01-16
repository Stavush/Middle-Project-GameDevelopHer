using TMPro;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    private float startTime;
    private float countdownDuration = 120.0f; // 2 minutes in seconds
    private float remainingTime;

    [SerializeField]
    private TMP_Text countdownText;
    [SerializeField]
    private GameObject losePopup;
    [SerializeField]
    private GameObject winPopup;

    void Start()
    {
        startTime = Time.time;
        remainingTime = countdownDuration;
        HidePopups();
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
            ShowWinPopup();
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
            ShowLosePopup();
        }
    }

    void UpdateCountdownUI()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60.0f);
        int seconds = Mathf.FloorToInt(remainingTime % 60.0f);
        string countdownString = string.Format("{0:00}:{1:00}", minutes, seconds);
        countdownText.SetText(countdownString);
    }

    void ShowWinPopup()
    {
        winPopup.SetActive(true);
    }

    void ShowLosePopup()
    {
        losePopup.SetActive(true);
    }

    void HidePopups()
    {
        losePopup.SetActive(false);
        winPopup.SetActive(false);
    }
}

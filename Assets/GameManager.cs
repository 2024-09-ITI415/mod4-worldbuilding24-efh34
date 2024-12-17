using UnityEngine;
using UnityEngine.UI; // Import UI namespace for Legacy Text

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text IntroText; // Reference to the introduction text
    [SerializeField] private Text WinText;   // Reference to the win text
    [SerializeField] private float introDuration = 3f; // Duration in seconds before the intro text disappears

    private void Start()
    {
        // Show the intro text at the start of the game
        IntroText.gameObject.SetActive(true);
        WinText.gameObject.SetActive(false);

        // Start a coroutine to hide the intro text after a delay
        StartCoroutine(HideIntroTextAfterDelay());
    }

    private System.Collections.IEnumerator HideIntroTextAfterDelay()
    {
        yield return new WaitForSeconds(introDuration); // Wait for the specified duration
        IntroText.gameObject.SetActive(false);          // Hide the intro text
    }

    public void OnAllCoinsCollected()
    {
        // Show the win text when all coins are collected
        WinText.gameObject.SetActive(true);
    }
}

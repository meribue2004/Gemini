using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 10f;  // Total time in seconds
    public float currentTime;     // Current time left
    public Image timeBarImage;     // Reference to the UI Image representing the time bar

    void Start()
    {
        // Initialize the current time to the total time
        currentTime = totalTime;
    }

    void Update()
    {
        // Update the current time
        currentTime -= Time.deltaTime;

        // Ensure the current time doesn't go below zero
        currentTime = Mathf.Max(currentTime, 0f);

        // Update the time bar UI
        UpdateTimeBarUI();

        // Check if time is up
        if (currentTime <= 0f)
        {
             FindObjectOfType<Healthstates>().DecreaselivesTimer();
             currentTime = totalTime;
            // Handle time-up logic here
            Debug.Log("Time's up!");
        }
    }

    void UpdateTimeBarUI()
    {
        // Calculate the fill amount for the time bar based on the current time and total time
        float fillAmount = currentTime / totalTime;

        // Update the fill amount of the time bar UI
        timeBarImage.fillAmount = fillAmount;
    }

    // Function to increase the player's total time
    //public void IncreaseTotalTime(float timeToAdd)
    //{
    //    totalTime += timeToAdd;
    //    Debug.Log("Player's Total Time: " + totalTime); // Optional: Display total time in the console
    //    // You can update a UI element to display the updated total time here if needed
    //    //timeBarImage.fillAmount = totalTime;
    //}
}

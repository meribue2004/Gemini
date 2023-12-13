using UnityEngine;
using UnityEngine.UI;



public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu; // reference to the pause menu
    public static bool isPaused;

    void Start()
    {
        // Check if pauseMenu is assigned before trying to access it
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
        else
        {
            Debug.LogError("PauseMenu: The 'pauseMenu' GameObject is not assigned in the Unity Editor.");
        }
    }

  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Check if the game is already paused
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        //SetPanelAlpha(0.69f);
        pauseMenu.SetActive(true); // Activate the menu
        Time.timeScale = 0f; // Stop time
        isPaused = true;
    }

    public void ResumeGame()
    {
        //SetPanelAlpha(0f);
        pauseMenu.SetActive(false); // Close the menu
        Time.timeScale = 1f; // Resume time
        isPaused = false;
    }
   // private void SetPanelAlpha(float alpha)
    // // {
    // //     Color panelColor = pauseMenuImage.color;
    // //     panelColor.a = alpha;
    // //     pauseMenuImage.color = panelColor;
    // // }
    public void GoToMainMenu(){
     Time.timeScale = 1f; // Resume time
     Application.LoadLevel(0);
    }
    public void QuitGame(){
     Application.Quit();
    }
}



using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class creditPlayNext : MonoBehaviour
{
     void Start()
    {
        // Invoke the LoadNextScene method after 6 seconds
        Invoke("LoadNextScene", 6f);
    }

    void LoadNextScene()
    {
        // Replace "YourNextSceneName" with the actual name of your next scene
        SceneManager.LoadScene("WinMenu");
    }
}

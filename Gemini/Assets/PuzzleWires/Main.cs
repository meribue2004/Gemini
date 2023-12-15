using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main Instance;
    public GameObject puzzle;
    public GameObject others;

    public int switchCount;
    public GameObject winText;
    private int onCount = 0;

    private void Awake()
    {
        Instance = this;
    }
    public void SwitchChange(int points) {
        onCount = onCount + points;
        if (onCount == switchCount)
        {
            winText.SetActive(true);
            Invoke("disapear", 1f);
            DialogueManager.isDialogueActive = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void disapear()
    {
        others.SetActive(true);
        puzzle.SetActive(false);
        Camera.main.orthographicSize = 7.6f;
    }

}

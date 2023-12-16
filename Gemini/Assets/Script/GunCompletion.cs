using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GunCompletion : MonoBehaviour
{
    public GameObject completeGun;
      private int currentSceneIndex;
    public static int counter = 0;
    public GameObject puzzle;
    public GameObject others;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter==5)
        {
            completeGun.SetActive(true);
            //SceneManager.LoadScene(currentSceneIndex + 1);
            Invoke("completed", 3f);
        }
    }

    void completed()
    {
        completeGun.SetActive(false);
        others.SetActive(true);
        puzzle.SetActive(false);
        DialogueManager.isDialogueActive = false;
        Camera.main.orthographicSize = 7.6f;
    }
}

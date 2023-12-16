using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallNext : MonoBehaviour
{
    private int currentSceneIndex;
    public jetpackmovment player;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && player.gunpieces==5) 
        {
            FindObjectOfType<AudioManager>().Play("portal");
            // Use SceneManager.LoadScene instead of Application.LoadLevel
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}

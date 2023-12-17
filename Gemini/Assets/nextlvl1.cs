using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlvl1 : MonoBehaviour
{
    private int currentSceneIndex;

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
    { int i = FindObjectOfType<Healthstates>().coinsCollected;
        if (collision.tag == "Player" &&(i==3))
        {
            FindObjectOfType<AudioManager>().Play("portal");
            // Use SceneManager.LoadScene instead of Application.LoadLevel
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}

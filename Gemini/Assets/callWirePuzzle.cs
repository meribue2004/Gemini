using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class callWirePuzzle : MonoBehaviour
{
    public GameObject Puzzle;
    public GameObject Others;
    private bool triggeredOnce;
    // Start is called before the first frame update
    void Start()
    {
        Others.SetActive(true);
        Puzzle.SetActive(false);
        triggeredOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !triggeredOnce)
        {
            DialogueManager.isDialogueActive = true;
            triggeredOnce = true;
            Puzzle.SetActive(true);
            Others.SetActive(false);
            Camera.main.orthographicSize = 5;
        }
    }


}

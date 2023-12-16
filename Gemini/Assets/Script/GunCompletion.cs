using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GunCompletion : MonoBehaviour
{
    public GameObject completeGun;
      private int currentSceneIndex;
    public static int counter = 0;
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
        }
    }
}

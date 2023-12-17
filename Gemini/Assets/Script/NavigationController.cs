using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NavigationController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMainMenu(){
     Time.timeScale = 1f; // Resume time
      Application.LoadLevel(0);
    }
    public void GoTograndlus(){
        SceneManager.LoadScene("grandpalus");
       }


    public void GoToLvl1(){
     
      SceneManager.LoadScene("grandpalus");
    }
      public void GoToCaught(){
     
      Application.LoadLevel(3);
    }
      public void GoToLvl2(){
     
      Application.LoadLevel(4);
    }
      public void GoToPuzzleWires(){
     
      Application.LoadLevel(5);
    }
  public void GoToControlRoom(){
     
      Application.LoadLevel(6);
    }
      public void GoToLvl3(){
     
      Application.LoadLevel(7);
    }
      public void GoToGunPuzzle(){
     
      Application.LoadLevel(8);
    }
      public void GoToLvl4(){
     
      Application.LoadLevel(9);
    }
      public void GoToLvl5(){
     
      Application.LoadLevel(10);
    }
      public void GoToEnding1(){
     
      Application.LoadLevel(11);
    }
     public void GoToEarth(){
     
      Application.LoadLevel(12);
    }
      public void GoToEnding2(){
     
      Application.LoadLevel(13);
    }
     public void GoToCredits(){
     
      Application.LoadLevel(14);
    }
     public void GoToDieMenu(){
     
      Application.LoadLevel(15);
    }
     public void GoToWinMeny(){
     
      Application.LoadLevel(16);
    }
     
    public void QuitGame(){
     Application.Quit();
    }
}


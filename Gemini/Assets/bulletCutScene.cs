using System.Collections;
using UnityEngine;

public class bulletCutScene : MonoBehaviour
{
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
        bullet.SetActive(false);
       
    }

    // IEnumerator ActivateBullet()
    // {
    //     yield return new WaitForSeconds(3.5f);
    //     bullet.SetActive(true);
    // }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag=="Player"){
         bullet.SetActive(true);
      }
      if(collision.tag=="Enemy"){
        Debug.Log("3aw");
        Destroy(gameObject);
      }
    }
      
    }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Image healthBar;
    public int health = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Method to handle taking damage
    public void TakeDamage(int damage)
    {
        //lab 8
        this.health=health - damage;
        healthBar.fillAmount= this.health/5f;
        // Check if the player is not immune to damage
      
            // Reduce player's health
            health -= damage;

            // Ensure health doesn't go below 0
            if (health < 0)
                health = 0;

            // Respawn logic if health is depleted
          
            // Game over if lives are exhausted
           

            // Log player health and lives
            Debug.Log("Player Health: " + health.ToString());
          
        

       
    }
}

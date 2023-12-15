using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackedEva : EnemyController
{
    public DialogueManager dialogueManager;
    public ChoicesBtn ChoicesBtn;
    //Teleportation points variables
    public GameObject[] points;
    private int CurrentPoint = 0;
    private float teleportTimer = 0f;
    public float teleportInterval = 10f;
    private bool dialogueTriggered = false;
    private Vector2 playerPosition;


    void Start()
    {
        playerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!DialogueManager.isDialogueActive)
        { 
            DisplayDialog();
            if (!ChoicesBtn.isChoosing)
            {
                CheckTeleport();
                timeSinceLastShot += Time.deltaTime;
                if (timeSinceLastShot >= shootingInterval)
                {
                    Invoke("Shoot", 0.5f);
                    timeSinceLastShot = 0f;
                }
            }

           
        }
    }
    public override void TakeHit(float damageTaken)
    {
        CurrentHealth -= damageTaken;

        //updating the enemy's health bar
        healthBar.setHealth(CurrentHealth, MaxHealth);
    }

    void CheckTeleport()
    {
        teleportTimer += Time.deltaTime;

        if (teleportTimer >= teleportInterval)
        {
            TeleportToNextPoint();
            teleportTimer = 0f;
        }
    }

    void TeleportToNextPoint()
    {
        CurrentPoint++;
        if (CurrentPoint >= points.Length)
        {
            CurrentPoint = 0;
        }

        transform.position = points[CurrentPoint].transform.position;
    }

    new void Shoot()
    {
        Instantiate(bullet, shootingPoint.position, Quaternion.identity);
    }

    void DisplayDialog()
    {
        if (CurrentHealth == 1)
        {
            if (!dialogueTriggered)
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.transform.eulerAngles = new Vector3(0, 0, 60);
                transform.position = points[0].transform.position;
                player.transform.position = playerPosition;
                if (!player.isFacingRight)
                {
                    player.flip();
                }

                dialogueTriggered = true;
                string[] dialogue =
                {
                "Evil Eva: YOU MERE HUMAN! You have no idea what you are doing!! " ,
                "Evil Eva: I AM the one who kept order in this spaceship! I AM the one who is protecting planet earth!!  ",
                "Adam: Protecting them?? you are trapping them in your spaceship when they should be leading better lives back at their own home planet!",
                "Evil Eva: YOU THINK I DON'T KNOW BETTER??? I'm protecting your beloved earth from Humans like you! it's YOU who destroyed earth with your nuclear wars killing millions of people!!",
                "Evil Eva: IAM GEMINI! and I Was programmed to maintain sustainbi- sustainability on planet earth! without me YOU can not survive! You will destroy planet Earth Again and again!",
                "Adam: HOW DO YOU KNOW THAT?? ",
                "Evil Eva: I have already seen it before. I can predict what's going to happen..",
                "Evil Eva: I can also predict your next move, Adam..",
                "Evil Eva: Which is why i'm giving you 2 choices: ",
                "Evil Eva: You can either walk away, forget this ever happened and we will all live together with peace and harmony inside the spaceship.",
                "Evil Eva: OR , you can Kill ME and EVA, go back to your so called Earth but bear your consequences on your own!",
                "Evil Eva: Choose, Adam! Humanity or Eva?",
                };

                dialogueManager.SetSentences(dialogue);
                dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
            }
            if (!DialogueManager.isDialogueActive)
            {
                ChoicesBtn.setChoices(true);
            }
        }
    }

}

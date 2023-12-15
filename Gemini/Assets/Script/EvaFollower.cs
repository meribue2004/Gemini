using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaFollower : MonoBehaviour
{
    private PlayerMovement player;
    public float maxspeed = 3f;
    public float behindDistance = 4f;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        // Calculate the target position to be 4 units behind the player
        Vector3 targetPosition = player.transform.position - (player.transform.right * behindDistance);

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, maxspeed * Time.deltaTime);
    }
}

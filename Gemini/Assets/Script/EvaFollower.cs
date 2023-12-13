using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaFollower : MonoBehaviour
{
    private PlayerMovement player;
    public float maxspeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, maxspeed * Time.deltaTime);
    }
}

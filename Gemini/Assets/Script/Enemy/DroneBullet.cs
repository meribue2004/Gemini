using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBullet : MonoBehaviour
{
    public int damage;
    private GameObject player;
    public Rigidbody2D rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        //Vector3 direction = player.transform.position;
        Vector2 movedir = (player.transform.position - transform.position).normalized * force;
        rb.velocity = new Vector2(movedir.x, movedir.y).normalized * force;


        float rot = Mathf.Atan2(-movedir.y, -movedir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot+180);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {

        if ( collider.CompareTag("Player"))
        {
            Debug.Log("Player collision");
            FindObjectOfType<Healthstates>().TakeDamage(damage);
            Destroy(gameObject);

        }
        if (collider.tag == "shield")
        {
            Destroy(gameObject);
        }
        else if (collider.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }


    }
}

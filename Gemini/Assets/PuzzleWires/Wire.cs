//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Wire : MonoBehaviour
//{
//    public SpriteRenderer wireEnd;
//    public GameObject lightOn;
//    Vector3 startPoint;
//    Vector3 startPosition;
//    // Start is called before the first frame update


//    void Start()
//    {
//        startPoint = transform.parent.position;
//        startPosition = transform.position;


//        // Retrieve the starting position
//        string startPositionString = PlayerPrefs.GetString("StartPosition");
//        Vector3 start = Vector3.zero;


//    }

//    private void OnMouseDrag()
//    {
//        // mouse position to world point
//        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        newPosition.z = 0;

//        // check for nearby connection points
//        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);
//        foreach (Collider2D collider in colliders)
//        {
//            // make sure not my own collider
//            if (collider.gameObject != gameObject)
//            {
//                // update wire to the connection point position
//                UpdateWire(collider.transform.position);

//                // check if the wires are same color
//                if (transform.parent.name.Equals(collider.transform.parent.name))
//                {
//                    // count connection
//                    Main.Instance.SwitchChange(1);

//                    // finish step
//                    collider.GetComponent<Wire>()?.Done();
//                    Done();
//                }
//                return;
//            }
//        }

//        // update wire
//        UpdateWire(newPosition);
//    }

//    void Done()
//    {
//        // turn on light
//        lightOn.SetActive(true);

//        // destory the script
//        Destroy(this);

//    }

//    private void OnMouseUp()
//    {
//        // reset wire position
//        UpdateWire(startPosition);
//    }

//    void UpdateWire(Vector3 newPosition)
//    {
//        // update position
//        transform.position = newPosition;

//        // update direction
//        Vector3 direction = newPosition - startPoint;
//        transform.right = direction * transform.lossyScale.x;

//        // update scale
//        float dist = Vector2.Distance(startPoint, newPosition);
//        wireEnd.size = new Vector2(dist, wireEnd.size.y);

//    }

//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public SpriteRenderer wireEnd;
    public GameObject lightOn;
    Vector3 startPoint;
    Vector3 startPosition;

    void Start()
    {
        startPoint = transform.parent.position;
        startPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);
        foreach (Collider2D collider in colliders)
        {
            if (collider != null && collider.gameObject != null && collider.gameObject != gameObject)
            {
                UpdateWire(collider.transform.position);

                if (collider.transform != null && collider.transform.parent != null && transform.parent != null &&
                    transform.parent.name.Equals(collider.transform.parent.name))
                {
                    Main.Instance.SwitchChange(1);

                    Wire wireComponent = collider.GetComponent<Wire>();
                    if (wireComponent != null)
                    {
                        wireComponent.Done();
                    }

                    Done(); // Call Done() method in the current script
                }
                return;
            }
        }


        UpdateWire(newPosition);
    }

    void Done()
    {
        lightOn.SetActive(true);
        Destroy(this);
    }

    private void OnMouseUp()
    {
        UpdateWire(startPosition);
    }

    void UpdateWire(Vector3 newPosition)
    {
        transform.position = newPosition;
        Vector3 direction = newPosition - startPoint;
        transform.right = direction * transform.lossyScale.x;
        float dist = Vector2.Distance(startPoint, newPosition);
        wireEnd.size = new Vector2(dist, wireEnd.size.y);
    }
}


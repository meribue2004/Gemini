using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform platform;
    public Transform start;
    public Transform end;
    int direction = 1;
    public float speed;



    void Start()
    {
        
    }
    
    private void Update()
    {
        Vector2 target = currentMovementTarget();
        platform.position = Vector2.Lerp(platform.position, target, speed * Time.deltaTime);
        float distance = (target - (Vector2)platform.position).magnitude;

        if (distance <= 0.1f)
        {
            direction *= -1;
        }
    }

    private void OnDrawGizmos()
    {
        if(platform!=null && start!=null && end != null)
        {
            Gizmos.DrawLine(platform.transform.position, start.position);
            Gizmos.DrawLine(platform.transform.position, end.position);
        }
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return start.position;
        }
        else
        {
            return end.position;
        }

    }


}

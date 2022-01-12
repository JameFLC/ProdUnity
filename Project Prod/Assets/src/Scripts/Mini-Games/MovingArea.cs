using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingArea : MonoBehaviour
{
    public float speed;
    public Transform waypointsLeft;
    public Transform waypointsRight;

    public Transform target;
    private int destPoint = 0;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
    }
    void Update()
    {
        Vector3 dir = Vector3.right;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        transform.position = Vector3.Lerp(waypointsLeft.position, waypointsRight.position, ((-Mathf.Cos(Time.time * speed) + 1) / 2));
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            //destPoint = (destPoint + 1) % waypoints.Length;
            //target = waypoints[destPoint];
        }
    }
}

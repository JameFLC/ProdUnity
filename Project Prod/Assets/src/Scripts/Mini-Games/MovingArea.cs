using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingArea : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    public Transform target;
    private int destPoint = 0;

    private void Start()
    {
        target = waypoints[0];
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
        }
    }
}

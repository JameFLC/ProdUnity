using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    // Variables
    [SerializeField]
    private Transform follow;
    [SerializeField] 
    float smoothTime = 0.05f;
    


    private Vector3 vel;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.1f);
    }
    private void Update()
    {

        transform.position = Vector3.SmoothDamp(transform.position, follow.position, ref vel, smoothTime);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    [SerializeField]
    private GameObject playerCamera;


    private Rigidbody RB;

    private Vector3 speed;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        speed.x = Input.GetAxis("Horizontal");
        speed.z = Input.GetAxis("Vertical");

    }
    private void FixedUpdate()
    {
        RB.MovePosition(new Vector3(speed.x, 0, speed.z));
    }
}

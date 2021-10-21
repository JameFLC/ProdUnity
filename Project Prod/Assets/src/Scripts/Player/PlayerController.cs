using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    [SerializeField]
    private Transform playerCamera;



    private FrogController frogController;
    private Rigidbody RB;
    float rotationSmootTime = 0.1f;
    float rotationSmoothVelocity;
    float speed = 5;
    float horizontal;
    float vertical;
    Vector3 direction;
    float targetAngle;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        frogController = GetComponent<FrogController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");


        if (vertical > 0.1)
        {
            frogController.Crawl();
        }
        if (vertical < 0.1 )
        {
            frogController.Idle();
        }



       
    }
    
}
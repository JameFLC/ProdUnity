using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variable
    [SerializeField]
    private Transform mainCamera;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float jumpHeight = 1f;
    [SerializeField]
    private float rotationTime = 0.1f;
    [SerializeField]
    private PlayerAnimationController playerAC;


    private bool isGrounded = true;
    private Rigidbody RB;
    private float rotationVelocity;
    private Vector3 inputDirection;
    Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float extra = 0.1f;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, extra);

        


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump(jumpHeight);
        }

        inputDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Update Animations
        playerAC.IsGrounded(isGrounded);
        playerAC.SetVerticalVelocity(RB.velocity.y);
        playerAC.SetSpeed(inputDirection.magnitude);
    }
    private void FixedUpdate()
    {
        if (inputDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationVelocity, rotationTime);



            moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            
            
            RB.MoveRotation(Quaternion.Euler(0f, angle, 0f));
            RB.MovePosition(transform.position + (moveDirection * speed * Time.fixedDeltaTime));
            
        }
        
    }
    void Jump(float Height)
    {
        RB.AddForce(new Vector3(0f, Mathf.Sqrt(jumpHeight * -2 * Physics.gravity.y), 0f) + moveDirection, ForceMode.VelocityChange);
    }
}
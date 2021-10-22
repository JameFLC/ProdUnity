using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    // Variables
    [SerializeField]
    private Animator frogAnimator;
    private
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IsGrounded(bool Grounded)
    {
        frogAnimator.SetBool("IsOnTheFloor", Grounded);
    }
    public void SetVerticalVelocity(float VellocityY)
    {
        frogAnimator.SetFloat("VerticalVelocity", VellocityY);

    }
    public void SetSpeed(float speed)
    {
        frogAnimator.SetFloat("Speed", speed);
        frogAnimator.SetFloat("CrawlSpeed", speed * 4);
    }

}

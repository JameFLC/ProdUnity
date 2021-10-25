using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    // Variables
    [SerializeField]
    private Animator frogAnimator;
    [SerializeField]
    private float crawlAnimationSpeed = 6.0f;


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
        frogAnimator.SetFloat("CrawlSpeed", speed  * crawlAnimationSpeed);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorController : MonoBehaviour
{
    // Variables
    [SerializeField]
    private GameObject frogsBody;
    [SerializeField] 
    private Material blue;
    [SerializeField] 
    private Material balckOnRedSpot;
    [SerializeField] 
    private Material orangeBlackBlue;
    [SerializeField] 
    private Material redGreenBlack;
    [SerializeField]
    private Material yellow;
    [SerializeField] 
    private Material yellowOnBlack;

    SkinnedMeshRenderer skinnedMeshRenderer;
    private void Awake()
    {
        skinnedMeshRenderer = frogsBody.GetComponent<SkinnedMeshRenderer>();

        YellowOnBlack();
    }


    public void Blue()
    {
        skinnedMeshRenderer.material = blue;
    }
    public void BalckOnRedSpot()
    {
        skinnedMeshRenderer.material = balckOnRedSpot;
    }
    public void OrangeBlackBlue()
    {
        skinnedMeshRenderer.material = orangeBlackBlue;
    }
    public void RedGreenBlack()
    {
        skinnedMeshRenderer.material = redGreenBlack;
    }
    public void Yellow()
    {
        skinnedMeshRenderer.material = yellow;
    }
    public void YellowOnBlack()
    {
        skinnedMeshRenderer.material = yellowOnBlack;
    }
}

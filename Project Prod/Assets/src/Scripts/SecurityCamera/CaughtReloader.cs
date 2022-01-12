using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaughtReloader : MonoBehaviour
{
    private SecurityCamera cam;
    private NextLevelTransition levelTransition;
    // Start is called before the first frame update
    void Awake()
    {
        cam = GetComponent<SecurityCamera>();
        levelTransition = FindObjectOfType<NextLevelTransition>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.currentlyTrackingTarget())
        {
            Debug.Log("Reload");
            levelTransition.RelaunchLevel();
        }
    }
}

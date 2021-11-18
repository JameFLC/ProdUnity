using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{


    public bool autoLockCursor;

    private Camera cam;

    void Awake()
    {
        
        Cursor.lockState = (autoLockCursor) ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = false; 
    }

    
    
    
    
    
    
    
    

    
    
    
    
    
    
    
    
    
}


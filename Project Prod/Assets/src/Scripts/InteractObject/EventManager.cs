using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnFireButtonClick();
    public static event OnFireButtonClick onFireButtonClick;
    public static void RaiseOnFireButtonClick()
    {
        if (onFireButtonClick!= null )
        {
            onFireButtonClick();
        }
    }
    
    public delegate void CallVigil();
    public static event CallVigil callVigil;
    public static void RaiseCallVigil()
    {
        if (callVigil != null )
        {
            callVigil();
        }
    }
    
    public delegate void OpenDoor();
    public static event OpenDoor openDoor;
    public static void RaiseOpenDoor()
    {
        if (openDoor != null )
        {
            openDoor();
        }
    }

    public delegate void LaunchMinigame();
    public static event LaunchMinigame launchMinigame;
    public static void RaiseLaunchMinigame()
    {
        if (launchMinigame != null)
        {
            launchMinigame();
        }
    }

}

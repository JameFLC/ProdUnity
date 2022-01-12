
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Reactions : MonoBehaviour
{
    //Note here the different reactions 
    public enum Choice
    {
        Dance,
        Chute,
        Lumiere,
        Porte,
        Minigame
    }

    [Header("Paramètre choix réaction")]
    //list of all available choices 
    [SerializeField]
    [Tooltip("Choix réaction.")]
    public List<Choice> L_Choice;

    //Parameter for different reactions 

    [Header("Paramètre Réaction")]
    //DanceReaction
    private Animator Animator = null;

    //Falling GameObject
    private Rigidbody Rig_GameObject = null;
    //Utility soon for detect ground
    //private bool falling = false;

    //Light trun
    private Light L_Light = null;

    //Detection zone around the impact zone
    //[SerializeField]
    //[Tooltip("Zone Detection vigile autour du point de chute")]
    public float DetectDistance = 100;


    public void Start()
    {
        if (GetComponent<Animator>()) { Animator = GetComponent<Animator>(); }
        if (GetComponent<Rigidbody>()) { Rig_GameObject = GetComponent<Rigidbody>(); }
        if (GetComponent<Light>()) { L_Light = GetComponent<Light>(); }
    }

    public void Reaction()
    {
        Debug.Log(this + " Has reacted");
        foreach (var e_Choice in L_Choice)
        {
            switch (e_Choice)
            {
                case Choice.Dance:
                    Animator.SetBool("DanceChangeInput", true);
                    break;
                case Choice.Chute:
                    Rig_GameObject.isKinematic = false;
                    //if(Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Vigil").transform.position) < DetectDistance)
                    //{
                    //    //EventManager.RaiseCallVigil();
                    //}
                    break;
                case Choice.Lumiere:
                    L_Light.enabled = !L_Light.enabled;
                    break;
                case Choice.Porte:
                    EventManager.RaiseOpenDoor();
                    break;
                case Choice.Minigame:
                    Debug.Log("Minigame");
                    SceneManager.LoadScene("Bargame");
                    
                    EventManager.RaiseLaunchMinigame();
                    break;
                default:
                    break;
            }
        }
    }
}

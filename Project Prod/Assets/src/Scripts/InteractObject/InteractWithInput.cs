using System.Collections.Generic;
using UnityEngine;

public class InteractWithInput : MonoBehaviour
{
    [Header("Paramètre pour intéraction avec un réactif par touche")]

    //Etat True = action
    [SerializeField]
    [Tooltip("Bolléen activation.")]
    public bool b_State = false;


    //Interactive True = Snap-in 
    [SerializeField]
    [Tooltip("Bolléen activable.")]
    public bool b_Interactive = true;

    //Instante reload
    [SerializeField]
    [Tooltip("Bolléen activable.")]
    public bool b_Reaload = false;

    //Text display to indicate the key to launch 
    private bool b_displayed = false;   

    //Distance to display
    [SerializeField]
    [Tooltip("Distance affichage touche activation.")]
    public float f_DistanceToDisplay = 0f;

    //Choice for activation
    [SerializeField]
    [Tooltip("Touche pour activation.")]
    public KeyCode k_Input;

    //Reactive object recovery 
    [SerializeField]
    [Tooltip("Objet réactif")]
    public List<GameObject> L_ReactionObjet;

    //Player GameObject
    private GameObject go_Player;

    //Prefab input display
    [SerializeField]
    [Tooltip("Prefab affichage touche")]
    public GameObject go_PrefabTextDisplay = null;
    private GameObject go_TextInputeDisplay;
    private TMPro.TextMeshProUGUI t_TextInput;


    void Start()
    {
        //Recover the player with his tag to facilitate
        go_Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //If interact is true
        if(b_Interactive && !b_State)
        {
            //Compare the distance between the day and the display area of the activation key
            if (Vector3.Distance(go_Player.transform.position, transform.position) < f_DistanceToDisplay && !b_displayed)
            {
                //Instantiate a display of the key to press 
                go_TextInputeDisplay = Instantiate(go_PrefabTextDisplay, transform);
                t_TextInput = go_TextInputeDisplay.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                t_TextInput.text = k_Input.ToString();
                b_displayed = true;
            }
        }

        if (b_displayed && !b_State)
        {
            //Compare the distance between the day and the display area of the activation key
            if (Vector3.Distance(go_Player.transform.position, transform.position) > f_DistanceToDisplay)
            {
                //Destroy key display
                Destroy(go_TextInputeDisplay);
                b_displayed = false;
            }

            //If the expected key is pressed
            if (Input.GetKeyDown(k_Input))
            {
                //Detection if the player is looking at the object to start the action
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.isTrigger)
                    {
                        if (!b_Reaload)
                        {
                            b_State = true;
                            Destroy(go_TextInputeDisplay);
                            b_displayed = false;
                        }
                        Debug.Log("Faire Action (Input)");

                        //Start all reaction
                        foreach (var go_ReactionObjet in L_ReactionObjet)
                        {
                            go_ReactionObjet.GetComponent<Reactions>().Reaction();
                        }
                    }
                }
            }
        }
    }

    

}

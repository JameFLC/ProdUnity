using System.Collections.Generic;
using UnityEngine;

public class InteractWithTrigger : MonoBehaviour
{
    [Header("Param�tre pour int�raction avec un r�actif par trigger")]
    [Header("Ne pas oublier de placer le trigger � la place voulu !")]

    //Etat True = action
    [SerializeField]
    [Tooltip("Boll�en activation.")]
    public bool b_State = false;

    //Interactive True = Snap-in 
    [SerializeField]
    [Tooltip("Boll�en activable.")]
    public bool b_Interactive = true;

    //Reactive object recovery 
    [SerializeField]
    [Tooltip("Objet r�actif")]
    public List<GameObject> L_ReactionObjet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(b_Interactive && !b_State)
            {
                b_State = true;
                Debug.Log("Faire action (Trigger)");

                //Start all reaction
                foreach (var go_ReactionObjet in L_ReactionObjet)
                {
                    go_ReactionObjet.GetComponent<Reactions>().Reaction();
                }
            }
        }
    }
}

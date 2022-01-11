using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_door : MonoBehaviour
{
    private bool isInRange;
    Animation myAnimation;
    // Start is called before the first frame update
    void Start()
    {
        myAnimation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        Open_door();
    }

    private void Open_door()
    {
        if(isInRange == true && Inventory.instance.content.Count != 0 && Input.GetKeyDown(KeyCode.E)) 
        {
            //TO DO LANCER ANIMATION PORTE
            Inventory.instance.ConsumeItem();
            myAnimation.Play();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;


        }
    }
}

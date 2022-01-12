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
        if (isInRange == true )
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Inventory.instance.content.Count != 0)
                {
                    //TO DO LANCER ANIMATION PORTE
                    Inventory.instance.ConsumeItem();
                    myAnimation.Play();
                    SoundManager.PlaySound(SoundManager.Sound.DoorOpen, transform.position);
                }
                else
                {
                    SoundManager.PlaySound(SoundManager.Sound.DoorLocked, transform.position);
                }
            }
            
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItems : MonoBehaviour
{
    private bool isInRange;
    public Items item;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            TakeItem();
        }
    }

    void TakeItem()
    {
        Debug.Log(Inventory.instance.content.Count);

        Inventory.instance.content.Add(item);
        Inventory.instance.UpdateInventoryUI();
        Destroy(gameObject);
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

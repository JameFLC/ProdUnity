using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastItem : MonoBehaviour
{
    [SerializeField] GameObject lastCard;
    // Start is called before the first frame update
    void Awake()
    {
        lastCard.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            lastCard.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Items> content = new List<Items>();
    public int contentCurrentIndex = 0;
    public Image itemUIImage;

    public static Inventory instance;




    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateInventoryUI();
    }

    

    public void ConsumeItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        Items currentItem = content[contentCurrentIndex];
        currentItem.activation = true;
        content.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUI();
    }

    public void GetNextItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        contentCurrentIndex++;
        if (contentCurrentIndex > content.Count - 1)
        {
            contentCurrentIndex = 0;
        }
        UpdateInventoryUI();
    }

    public void GetPreviousItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        contentCurrentIndex--;
        if (contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if (content.Count > 0)
        {
            itemUIImage.sprite = content[contentCurrentIndex].image;
        }
        else
        {
            itemUIImage.sprite = null;
        }
        
    }
}

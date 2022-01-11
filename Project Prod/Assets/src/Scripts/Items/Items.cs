using UnityEngine;


[CreateAssetMenu(fileName ="Items", menuName = "Inventory/Items")]
public class Items : ScriptableObject
{
    public int id;
    public string name;
    public string description;
    public Sprite image;
    public bool activation = false;


    void Start()
    {
        activation = false;
    }
}

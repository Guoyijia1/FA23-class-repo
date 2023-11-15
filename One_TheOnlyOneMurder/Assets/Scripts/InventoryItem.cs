
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScritableObjects/NewInventoryItem", order = 1)]
public class InventoryItem : ScriptableObject
{
    public bool itemOwned;

    public string itemName;
    public Sprite itemIcon;


    public bool combinable;
    public InventoryItem[] combinableItems;
    public string[] successBlockNames;
    public string failBlockName;
    public Text text;
}

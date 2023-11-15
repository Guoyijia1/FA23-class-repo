using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour
{
    public InventoryItem item;
    private Inventory inventory;

    public Image image;
    private TextMeshProUGUI textBox;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();

        textBox = GetComponentInChildren<TextMeshProUGUI>();


    }

    public void DisplayItem(InventoryItem thisitem)
    {
        item = thisitem;
        textBox.text = item.itemName;
        image.sprite = item.itemIcon;
        gameObject.SetActive(true);
    }


    public void ClearItem()
    {
        item = null;
        image.sprite = null;
        gameObject.SetActive(false);

    }







}

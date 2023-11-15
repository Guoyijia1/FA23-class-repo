using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using System.Linq;
using static UnityEngine.GraphicsBuffer;
//Linq convery array to list

public class Inventory : MonoBehaviour
{
    private MenuDialog[] menuDialogs;//we have menuDialog, we want to pause it when we open our inventory menu
    private SayDialog[] sayDialogs;
    public CanvasGroup canvasGroup;
    //private Target target;//the reference in the Target script, we want to controll player not walk toward item when we click it

    public InventoryItem[] inventoryItems;
    public ItemSlot[] itemSlots;

    private Flowchart[] flowcharts;

    private void Start()
    {
        menuDialogs = FindObjectsOfType<MenuDialog>();
        sayDialogs = FindObjectsOfType<SayDialog>();
        canvasGroup = GetComponent<CanvasGroup>();
        //target = FindObjectOfType<Target>();

        flowcharts = FindObjectsOfType<Flowchart>();

    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))//using unity input system, add it in, creat"Inventory" in Input Manager
        {
            ToggleInventory(!canvasGroup.interactable);//do the oppsite when press, so it was like-turn it on and off
        }
    }

    private void ToggleInventory(bool setting)
    {
        ToggleCanvasGroup(canvasGroup, setting);
        InitializeItemSlots();

        foreach (MenuDialog menuDialog in menuDialogs)
        {
            ToggleCanvasGroup(menuDialog.GetComponent<CanvasGroup>(), !setting);


        }

        foreach (SayDialog sayDialog in sayDialogs)
        {
            //sayDialog.dialogEndabled = !setting;//第三十分钟
            if (setting) { Time.timeScale = 0f; } else { Time.timeScale = 1f; }
            ToggleCanvasGroup(sayDialog.GetComponent<CanvasGroup>(), !setting);
        }


    }


    
    public void InitializeItemSlots()//we refresh the item we use/own right now
    {
        List<InventoryItem> ownedItems = GetOwnedItems(inventoryItems.ToList());
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if(i < ownedItems.Count)
            {
                itemSlots[i].DisplayItem(ownedItems[i]);
            }
            else
            {
                itemSlots[i].ClearItem();
            }
        }

    }

    

    public List<InventoryItem> GetOwnedItems(List<InventoryItem> inventoryItems)
    {
        List<InventoryItem> ownedItems = new List<InventoryItem>();
        foreach (InventoryItem item in inventoryItems)
        {
            if (item.itemOwned)
            {
                ownedItems.Add(item);
            }
        }
        return ownedItems;
    }


    public void CombineItems(InventoryItem item1, InventoryItem item2)
    {
        if(item1.combinable == true && item2.combinable == true)
        {
            for(int i = 0; i < item1.combinableItems.Length; i++)
            {
                if (item1.combinableItems[i] == item2)
                {
                    foreach(Flowchart flowchart in flowcharts)
                    {
                        if (flowchart.HasBlock(item1.successBlockNames[i]))
                        {
                            ToggleInventory(false);
                            //target.EnterDialogue();
                            flowchart.ExecuteBlock(item1.successBlockNames[i]);
                            return;
                        }
                    }
                }
            }
        }
        foreach(Flowchart flowchart in flowcharts)
        {
            if (flowchart.HasBlock(item1.failBlockName))
            {
                ToggleInventory(false);
                //target.EnterDialogue();
                flowchart.ExecuteBlock(item1.failBlockName);
                
            }
        }
    }


    private void ToggleCanvasGroup(CanvasGroup canvasGroup, bool setting)
    {
        canvasGroup.alpha = setting ? 1f : 0f;//visible or invisible?
        canvasGroup.interactable = setting;
        canvasGroup.blocksRaycasts = setting;
    }


}

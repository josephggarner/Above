using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{



    #region Singleton

    internal static Inventory instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of Inventory Found!");
            return;
        }
        instance = this;
    }
    #endregion


    private bool isInventoryOpen = false;
    public List<Item> items = new List<Item>();
    public void Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            items.Add(item);
        }
        
    }
    
    public void Remove(Item item)
    {
        items.Remove(item);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i") && !isInventoryOpen)
        {
            isInventoryOpen = true;
            Debug.Log("Inventory is open!");
        }
        else if (Input.GetKeyDown("i") && isInventoryOpen)
        {
            isInventoryOpen = false;
            Debug.Log("Inventory is closed");
        }

        if (isInventoryOpen)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
    }
    public bool GetInventoryStatus()
    {
        return isInventoryOpen;
    }
}

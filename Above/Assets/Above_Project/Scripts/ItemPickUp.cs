using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    /*
    public override void Interact()
    {
        base.Interact();
        PickUp();

    }*/
    //when joey's dumbass does the interact;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            PickUp();
        }
    }
    void PickUp()
    {
        Debug.Log("Picked up" + item.name);
        Inventory.instance.Add(item);
       Destroy(gameObject);
    }
}

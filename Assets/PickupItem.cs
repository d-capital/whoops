using System;
using TMPro;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Inventory inventory;
    public GameObject inventoryItem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
    }

    public void OnMouseDown()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                //Add item to inventory
                inventory.isFull[i] = true;
                GameObject instantiatedItem = Instantiate(inventoryItem, inventory.slots[i].transform, false);
                //TODO: write down rect transform position
                instantiatedItem.GetComponent<InventoryItem>();
                if (instantiatedItem != null)
                {
                    instantiatedItem.GetComponentInParent<InventoryItem>().SetInitObjectPosition();
                }

                Destroy(gameObject);
                break;
            }
        }
    }
}

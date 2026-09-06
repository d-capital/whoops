using System.Collections;
using UnityEngine;

public class Wax:DropAction
{
    [SerializeField]
    public Inventory inventory;

    [SerializeField]
    public GameObject inventoryItem;

    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
    }
    public override bool Activate(string itemName)
    {
        Debug.Log("Wax: drop action initiated");
        if (inventoryItem && itemName == "Oil") 
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

                    StartCoroutine(WaitAndDestroy(0.5f));
                    return true;
                }
            }
        }
        return false;
    }

    IEnumerator WaitAndDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        int slotId = gameObject.GetComponentInParent<InventoryItem>().slotId;
        inventory.isFull[slotId] = false;
        Destroy(gameObject);
    }
}

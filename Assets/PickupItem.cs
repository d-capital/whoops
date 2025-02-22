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
        Instantiate(inventoryItem, inventory.transform, false);
        Destroy(gameObject);
    }
}

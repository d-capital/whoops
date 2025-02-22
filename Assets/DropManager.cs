using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropManager : MonoBehaviour, IDropHandler
{

    public bool objectReceived = false;
    public AudioSource audioSource;
    public Texture2D cursor;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<InventoryItem>())
            {
                objectReceived = true;
                GameObject.Destroy(eventData.pointerDrag);
                var DroppableItems = GameObject.FindGameObjectsWithTag("droppable");
                foreach (var i in DroppableItems)
                {
                    i.layer = 0;
                }
                eventData.pointerDrag.gameObject.GetComponent<Canvas>().overrideSorting = false;
                ApplyItem();
            }
            else
            {
                //eventData.pointerDrag.gameObject.transform.position = eventData.pointerDrag.gameObject.GetComponent<Spawn>().initObjectPos;
                eventData.pointerDrag.gameObject.GetComponent<Canvas>().overrideSorting = false;
            }
        }
    }

    void ApplyItem() 
    { 
        //
    }
}

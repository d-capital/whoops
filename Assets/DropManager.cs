using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using YG;

public class DropManager : MonoBehaviour
{
    private GameObject draggedObject;
    public static DropManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartDrag(GameObject obj)
    {
        draggedObject = obj;
    }

    public void Drop(Vector2 screenPos)
    {
        string itemName = "";
        if (draggedObject == null) return;
        // First try UI raycast (for Canvas-based drop zones)
        if (EventSystem.current != null)
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                position = screenPos
            };

            var results = new System.Collections.Generic.List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);
            

            foreach (var r in results)
            {
                var go = r.gameObject;

                // ignore hits that belong to the dragged object itself
                if (draggedObject != null && (go == draggedObject || go.transform.IsChildOf(draggedObject.transform)))
                    continue;

                // find DropAction on the hit or its parents
                var action = go.GetComponentInParent<DropAction>();
                GameObject targetGO = action != null ? action.gameObject : null;

                // if no DropAction, accept objects tagged as droppable (search parents)
                if (targetGO == null)
                {
                    Transform t = go.transform;
                    while (t != null)
                    {
                        if (t.gameObject.CompareTag("droppable"))
                        {
                            targetGO = t.gameObject;
                            break;
                        }
                        t = t.parent;
                    }
                }

                if (targetGO != null)
                {
                    itemName = draggedObject.GetComponentInChildren<InventoryItemDialogue>().ItemName;
                    Debug.Log($"Дроп успешно! (UI) - Dropped '{draggedObject.name}' on '{targetGO.name}'");
                    // call DropAction if available
                    if (action != null) 
                    {
                        bool result = action.Activate(itemName);
                        if (result) 
                        {
                            var dialogue = draggedObject.GetComponentInChildren<InventoryItemDialogue>();
                            if (dialogue != null) Destroy(dialogue.gameObject);
                        }
                    }

                    draggedObject = null;
                    return;
                }
            }
        }

        // Fallback to 2D world physics check (convert screen -> world)
        Camera cam = Camera.main;
        if (cam != null)
        {
            Vector2 worldPoint = cam.ScreenToWorldPoint(screenPos);
            Collider2D col = Physics2D.OverlapPoint(worldPoint);
            if (col != null)
            {
                // ignore if overlap is part of the dragged object's world representation
                if (draggedObject != null && col.gameObject == draggedObject) { /* skip */ }
                else if (col.CompareTag("droppable"))
                {
                    Debug.Log($"Дроп успешно! (World) - Dropped '{draggedObject.name}' on '{col.gameObject.name}'");
                    var action = col.GetComponent<DropAction>();
                    itemName = draggedObject.GetComponentInChildren<InventoryItemDialogue>().ItemName;
                    if (action != null) 
                    {
                        bool result = action.Activate(itemName);
                        if (result)
                        {
                            var dialogue = draggedObject.GetComponentInChildren<InventoryItemDialogue>();
                            if (dialogue != null) Destroy(dialogue.gameObject);
                        }
                    }
                }
            }
        }
        draggedObject = null;
    }
}
using System;
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
        if (draggedObject == null) return;

        // Проверка попадания в дроп‑зону
        RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);
        if (hit.collider != null && hit.collider.CompareTag("droppable"))
        {
            Debug.Log("Дроп успешно!");
            // Ваша логика обработки
            if (hit.collider.GetComponents<InventoryItem>().Length > 0)
            {
                hit.collider.GetComponentInChildren<DropAction>().Activate();
            }
            else
            {
                hit.collider.GetComponent<DropAction>().Activate();
            }

            Destroy(draggedObject);
        }
        draggedObject = null;
    }
}
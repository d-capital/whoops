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
            hit.collider.GetComponent<DropAction>().HideItem();
            Destroy(draggedObject);
        }
        draggedObject = null;
    }
}
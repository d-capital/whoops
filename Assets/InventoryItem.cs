using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] GameObject canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Vector3 initObjectPos;
    public Texture2D cursor;
    public Camera mainCamera;
    [SerializeField] string itemType;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        DropManager.Instance.StartDrag(gameObject);
        var DroppableItems = GameObject.FindGameObjectsWithTag("droppable");
        foreach (var i in DroppableItems)
        {
            i.layer = 3;
        }
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        initObjectPos = rectTransform.position;
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        var mousePos = Input.mousePosition;
        var mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
        var mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);
        DropManager.Instance.Drop(mousePosWorld2D);
        //all exceptions shold go here
        //TODO: throws exception cause toilet door is not there yet on lvl1
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        var DroppableItems = GameObject.FindGameObjectsWithTag("droppable");
        foreach (var i in DroppableItems)
        {
            i.layer = 0;
        }
        returnObjectIfNeeded();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void returnObjectIfNeeded()
    {
        StartCoroutine(checkIfObjectWasAppliedToTargetWithDelay());
    }

    IEnumerator checkIfObjectWasAppliedToTargetWithDelay()
    {
        yield return new WaitForSeconds(1.0f);
            rectTransform.anchoredPosition = initObjectPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / GameObject.FindAnyObjectByType<Canvas>().scaleFactor;
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            if (itemType == "Wax" && eventData.pointerDrag.GetComponent<InventoryItem>().name.Contains("oil"))
            {
                Debug.Log("Dropped wax on oil");
                //Debug.Log(eventData.pointerDrag);
            }
        }
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}

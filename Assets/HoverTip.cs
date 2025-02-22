using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTip : MonoBehaviour
{
    public GameObject tooltipUI;
    public TMP_Text tooltipText;
    public string text;
    public Camera mainCamera;

    private void Start()
    {
        tooltipUI.SetActive(false);
    }

    void OnMouseOver()
    {
        tooltipUI.SetActive(true);
        tooltipText.text = text;

        Vector2 mousePos = Input.mousePosition;
        var mousePosOrginal = mousePos;
        var mousePosWorld = mainCamera.ScreenToWorldPoint(mousePosOrginal);
        var mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);
        tooltipUI.transform.position = mousePosWorld2D;
    }

    void OnMouseExit()
    {
        HideTooltip();
    }

    public void HideTooltip() 
    {
        tooltipUI.SetActive(false);
    }


}

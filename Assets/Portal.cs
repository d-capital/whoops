using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Portal : MonoBehaviour
{

    public GameObject currentPlace;
    public GameObject targetPlace;
    public GameObject detectiveDiz;
    public GameObject tragetDetectiveLocation;
    public int detectiveSpriteDirection; //-1 or 1

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToPlace() 
    { 
        currentPlace.SetActive(false);
        targetPlace.SetActive(true);
        detectiveDiz.transform.position = tragetDetectiveLocation.transform.position;
        detectiveDiz.transform.localScale = new Vector3(detectiveSpriteDirection, 
            detectiveDiz.transform.localScale.y, 
            detectiveDiz.transform.localScale.z);
        HoverTip[] hoverTips = FindObjectsByType<HoverTip>(FindObjectsSortMode.None);
        foreach (HoverTip hoverTip in hoverTips) {
            hoverTip.HideTooltip();
        }
    }
}

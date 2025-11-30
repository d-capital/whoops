using UnityEngine;

public class MiniGameObject : MonoBehaviour
{

    public GameObject DrawerScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        ShowDrawerLock();
    }

    private void ShowDrawerLock() { 
        DrawerScreen.SetActive(true);
    }
}

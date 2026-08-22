using UnityEngine;

public class Wax:DropAction
{
    public override void Activate()
    {
        Debug.Log("Wax: drop action initiated");
        gameObject.SetActive(false);
    }
}

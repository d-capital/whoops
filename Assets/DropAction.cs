using UnityEngine;

public class DropAction : MonoBehaviour
{
   public virtual bool Activate(string itemName)
    {
        Debug.Log("Drop action initiated: " + itemName);
        return true;
    }
}

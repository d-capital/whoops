using UnityEngine;

public class Poster: DropAction
{
    public override bool Activate(string itemName)
    {
        Debug.Log("Poster: drop action initiated");
        if(itemName == "Rag") 
        {
            gameObject.SetActive(false);
            return true;
        }

        return false;
    }
}

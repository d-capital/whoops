using UnityEngine;

public class Braber: DropAction
{
    public override bool Activate(string itemName)
    {
        Debug.Log("Braber: drop action initiated");
        if(itemName == "Gel")
        {
            GetComponentInParent<CharacterDialogue>().StartDialogue("Busy", false);
            return true;
        }
        return false;
    }

}

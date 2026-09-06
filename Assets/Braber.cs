using UnityEngine;

public class Braber: DropAction
{
    public GameObject closedDoor;
    public override bool Activate(string itemName)
    {
        Debug.Log("Braber: drop action initiated");
        if(itemName == "Gel")
        {
            GetComponentInParent<CharacterDialogue>().StartDialogue("Busy", false);
            Destroy(closedDoor.GetComponent<CharacterDialogue>());
            closedDoor.GetComponent<Portal>().enabled = true;
            return true;
        }
        return false;
    }

}

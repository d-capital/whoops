using UnityEngine;

public class ChangeDialogueState : MonoBehaviour
{
    public CharacterDialogue characterDialogue;
    public string newState;

    public void OnMouseDown() 
    { 
        characterDialogue.currenDialogueState = newState;
    }
}

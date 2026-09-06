using System.Linq;
using UnityEngine;

public class InventoryItemDialogue : MonoBehaviour
{
    [SerializeField] public string ItemName;
    [SerializeField] CharacterDialogue Diz; // Replace with your actual object
    [SerializeField] string State;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Diz = FindObjectsByType<CharacterDialogue>().Where(x => x.CharacterName == "Diz").FirstOrDefault();
    }

    public void ShowDialogue()
    {
        if (Diz != null)
        {
            Diz.StartDialogue(State, false);
        }
    }
}

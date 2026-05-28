using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScreenInput : MonoBehaviour
{
    [SerializeField] string correctCode = "12297";
    [SerializeField] TMP_Text inputField;
    [SerializeField] int MaxCharacters = 5;
    [SerializeField] int MinCharacters = 0;
    [SerializeField] GameObject DrawerLock;
    [SerializeField] CharacterDialogue Diz; // Replace with your actual object
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject inventoryItem;
    public void WriteNumber(string number)
    {
        if(inputField.text.Count() < MaxCharacters)
        {
            inputField.text += number;
        }
    }

    public void Backspace()
    {
        if (inputField.text.Count() > MinCharacters)
        {
            inputField.text = inputField.text.Remove(inputField.text.Length -1);
        }
    }

    public void SubmitCode()
    {
        if(inputField.text == correctCode)
        {
            Debug.Log("Correct");
            DrawerLock.SetActive(false);
            Diz.StartDialogue("FoundEnemiesList", false);
            this.AddEnemiesListToInventory();
        }
        else
        {
            Debug.Log("Incorrect");
        }
    }

    public void AddEnemiesListToInventory()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                //Add item to inventory
                inventory.isFull[i] = true;
                Instantiate(inventoryItem, inventory.slots[i].transform, false);
                Destroy(gameObject);
                break;
            }
        }
    }
}

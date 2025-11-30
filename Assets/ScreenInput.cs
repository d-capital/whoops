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
        }
        else
        {
            Debug.Log("Incorrect");
        }
    }
}

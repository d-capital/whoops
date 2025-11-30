using UnityEngine;
using TMPro;

public class NumberButton : MonoBehaviour
{
    [SerializeField] string assignedNumber; 
    [SerializeField] ScreenInput inputField;
    
    public void setNumber()
    {
        inputField.WriteNumber(assignedNumber);
    }
}

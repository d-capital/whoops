using System;
using TMPro;
using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    public TMP_Text text;
    public string state;
    [SerializeField] public CharacterDialogue character;
    public AnswerGridControl AnswerGridControl;

    public void Answer() 
    {
        AnswerGridControl.gameObject.SetActive(false);
        character.StartDialogue(state, false);
    }

}

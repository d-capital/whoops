using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CharacterDialogue : MonoBehaviour
{
    public string CharacterName;
    public Sprite Avatar;
    public DialogueBoxHandler DialogueBoxHandler;
    public AnswerGridControl AnswerGridControl;

    public List<Dialogue> dialogues;

    public GameManager gameManager;

    public string currenDialogueState = "Initial";
    public int currentDialogueLineId = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartDialogue(string state, bool useCurrentState)
    {
        if (useCurrentState)
        {
            state = currenDialogueState;
        }
        
        gameManager.activeCharacter = this;
        currentDialogueLineId = 0;
        if(dialogues.Find(x => x.State == state).DialogueLines.Count > 0) 
        {
            DialogueLine lineToShow = dialogues.Find(x => x.State == state).DialogueLines[0];
            DialogueBoxHandler.ShowDialogueLine(CharacterName, Avatar, lineToShow.Line);
            currenDialogueState = state;
            currentDialogueLineId++;
        }
        else 
        {
            DialogueBoxHandler.HideDialogueBox();
            Debug.LogWarning("Something went wrong with the dialogue!");
        }

    }

    public void ShowNextLine()
    {
        Dialogue currentDialogue = dialogues.Find(x => x.State == currenDialogueState);
        List<DialogueLine> currentDialogueLines = currentDialogue.DialogueLines;
        if (currentDialogueLineId <= currentDialogueLines.Count-1)
        {
            if (currentDialogueLines[currentDialogueLineId].Answers.Count > 0) 
            {
                DialogueBoxHandler.HideDialogueBox();
                AnswerGridControl.AddAnswers(currentDialogueLines[currentDialogueLineId].Answers);
            }
            else
            {
                DialogueLine dialogueLine = currentDialogueLines[currentDialogueLineId];
                DialogueBoxHandler.ShowDialogueLine(dialogueLine.Name, dialogueLine.Avatar, dialogueLine.Line);
            }
            currentDialogueLineId++;
        }
        else
        {
            if(currenDialogueState == "End")
            {
                currenDialogueState = "Return";
            }
            gameManager.activeCharacter = null;
            DialogueBoxHandler.HideDialogueBox();
        }
    }
}
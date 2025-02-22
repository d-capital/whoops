using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class AnswerGridControl : MonoBehaviour
{
    [SerializeField]
    GameObject AnswerButtonPrefab;
    public void RemoveAllAnswers()
    {
        if (this.transform.childCount > 0)
        {
            foreach (Transform child in this.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    public void AddAnswers(List<Answer> answers)
    {
        gameObject.SetActive(true);
        RemoveAllAnswers();
        foreach(Answer answer in answers)
        {
            GameObject answerButton = Instantiate(AnswerButtonPrefab, new Vector3(0, 0, 0), Quaternion.identity, this.transform) as GameObject;
            answerButton.GetComponent<AnswerButton>().text.text = answer.AnswerContent;
            answerButton.GetComponent<AnswerButton>().state = answer.OutputState;
            answerButton.GetComponent<AnswerButton>().character = answer.character;
            answerButton.GetComponent<AnswerButton>().AnswerGridControl = this;
        }
    }
}

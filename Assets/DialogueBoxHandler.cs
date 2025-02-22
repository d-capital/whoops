using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogueBoxHandler : MonoBehaviour
{
    public Image Avatar;
    public TMP_Text CharacterName;
    public TMP_Text DialogueLine;

    [SerializeField] bool leadingCharBeforeDelay = false;
    [SerializeField] string leadingChar = "";
    [SerializeField] float delayBeforeStart = 0f;
    [SerializeField] float timeBtwChars = 0.01f;

    string writer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDialogueLine(string characterName, Sprite AvatarImage, string dialogueLine) 
    {
        gameObject.SetActive(true);
        StopAllCoroutines();
        writer = "";
        CharacterName.text = characterName;
        Avatar.sprite = AvatarImage;
        writer = dialogueLine;
        StartCoroutine(TypeWriterTMP(DialogueLine));
    }
    IEnumerator TypeWriterTMP(TMP_Text _tmpProText)
    {
        _tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";

        yield return new WaitForSeconds(delayBeforeStart);

        foreach (char c in writer)
        {
            if (_tmpProText.text.Length > 0)
            {
                _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
            }
            _tmpProText.text += c;
            _tmpProText.text += leadingChar;
            yield return new WaitForSeconds(timeBtwChars);
        }

        if (leadingChar != "")
        {
            _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
        }
    }

    public void HideDialogueBox()
    {
        this.gameObject.SetActive(false);
    }

}

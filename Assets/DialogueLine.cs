using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class DialogueLine
{
    public int Id;
    public string Name;
    public Sprite Avatar;
    public string Line;
    public List<Answer> Answers;
    
}

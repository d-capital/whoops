using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[Serializable]
public class Dialogue
{
    public string State;
    public List<DialogueLine> DialogueLines;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3,10)]
    public string[] sentences;

    public Color color;

    public Sprite photo;

    public bool hasNext;
    public bool isLast;
    public GameObject nextDialogue;
}

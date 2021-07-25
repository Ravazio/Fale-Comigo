using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNext : MonoBehaviour
{
    public Dialogue dialogue;
    private void Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}

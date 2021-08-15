using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerCutscene : MonoBehaviour
{
    public float speed = 1f;
    public Dialogue dialogue;
    private void Start(){
        FunctionTimer.Create(TriggerDialogue, speed);
    }
    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}

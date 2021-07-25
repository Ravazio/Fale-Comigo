using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerCutscene : MonoBehaviour
{

    public Dialogue dialogue;
    private FunctionTimer functionTimer;
    private void Start(){
        FunctionTimer.Create(TriggerDialogue, 1f);
    }
    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}

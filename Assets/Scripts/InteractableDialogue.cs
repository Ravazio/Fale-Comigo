using UnityEngine;

public class InteractableDialogue : Interactable
{
    public DialogueManager dialogueManager;
    public Dialogue dialogue;

    public override void Interact()
    {
        dialogueManager.StartDialogue(dialogue);
    }
}

using UnityEngine;

public class InteractableDialogue : Interactable
{
    public Dialogue dialogue;

    public override void Interact()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}

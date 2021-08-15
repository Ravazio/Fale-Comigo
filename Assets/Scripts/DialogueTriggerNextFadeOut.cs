using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNextFadeOut : MonoBehaviour
{
    public Dialogue dialogue;

    public SpriteRenderer rend;

    private void Start()
    {
        startFading();

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void startFading()
    {
        StartCoroutine("FadeOut");
    }
}

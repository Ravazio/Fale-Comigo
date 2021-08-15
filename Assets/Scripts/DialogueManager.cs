using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public Image photo;

    private Queue<string> sentences;

    public Animator animator;

    public bool hasNext;
    public bool isLast;

    public bool faleComigo;

    private GameObject nextDialogue;
    public LevelLoaderScript levelLoader;

    private GameObject soundtrack;

    public float transitionTime = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Começando conversa com " + dialogue.name);

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        nameText.color = dialogue.color;

        photo.sprite = dialogue.photo;

        hasNext = dialogue.hasNext;
        isLast = dialogue.isLast;
        nextDialogue = dialogue.nextDialogue;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            if (hasNext){
                nextDialogue.SetActive(true);
            }
            if (isLast)
            {
                soundtrack = GameObject.FindGameObjectWithTag("Soundtrack");
                Destroy(soundtrack);
                levelLoader.LoadNextLevel();
            }
            return;
        }

        string sentence = sentences.Dequeue();
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        //dialogueText.text = sentence;
    }

    IEnumerator TypeSentence(string sentence)
    {
        if (!faleComigo)
        {
            AudioManager.instance.SpeakWordsOnLoop();
        }
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            if (faleComigo)
            {
                AudioManager.instance.BipSound();
            }
            dialogueText.text += letter;
            yield return new WaitForSeconds(transitionTime);
        }
        AudioManager.instance.StillSpeaking = false;
    }

    public void EndDialogue()
    {
        Debug.Log("Fim de conversa");

        animator.SetBool("IsOpen", false);
    }

}

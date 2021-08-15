using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNextSpecialCourtEnd : MonoBehaviour
{
    public Dialogue dialogue;

    public float speed;
    public float limit;
    private float counter;
    private GameObject person;
    private GameObject boundarie;
    private GameObject abstrato;

    private Vector3 normalizeDirection;

    private void Start()
    {
        counter = 0f;
        normalizeDirection = Vector3.right;
        person = GameObject.FindGameObjectWithTag("Person");
        boundarie = GameObject.Find("Right-Block");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

        abstrato = GameObject.Find("Jogador-Abstrato");
        Destroy(abstrato);
    }

    void Update()
    {
        if(counter < limit)
        {
            person.transform.position += normalizeDirection * speed * Time.deltaTime;
            boundarie.transform.position += normalizeDirection * speed * Time.deltaTime;
            counter++;
        }
    }
}

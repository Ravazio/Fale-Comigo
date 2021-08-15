using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNextSpecialCourt : MonoBehaviour
{
    public Dialogue dialogue;

    public float speed;
    public float limit;
    private float counter;
    private GameObject camera;
    private GameObject boundarie;

    private Vector3 normalizeDirection;

    private void Start()
    {
        counter = 0f;
        normalizeDirection = Vector3.left;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        boundarie = GameObject.Find("Left");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void Update()
    {
        if(counter < limit)
        {
            camera.transform.position += normalizeDirection * speed * Time.deltaTime;
            boundarie.transform.position += normalizeDirection * speed * Time.deltaTime;
            counter++;
        }
    }
}

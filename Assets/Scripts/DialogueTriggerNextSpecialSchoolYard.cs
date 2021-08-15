using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNextSpecialSchoolYard : MonoBehaviour
{
    public Dialogue dialogue;

    public float speed;
    public float limit;
    private float counter;

    private GameObject camera;

    private Vector3 normalizeDirection;

    private void Start()
    {
        counter = 0f;
        normalizeDirection = Vector3.right;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void Update()
    {
        if (counter < limit)
        {
            camera.transform.position += normalizeDirection * speed * Time.deltaTime;
            counter++;
        }
    }
}

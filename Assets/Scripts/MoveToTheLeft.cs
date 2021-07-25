using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTheLeft : MonoBehaviour
{
    private Vector3 normalizeDirection;
    public float speed;

    void Start()
    {
        normalizeDirection = Vector3.left;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += normalizeDirection * speed * Time.deltaTime;
    }
}

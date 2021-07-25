using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraToLeft : MonoBehaviour
{
    private float speed = 20;

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.Translate(new Vector3(- speed * Time.deltaTime, 0, 0));
    }
}

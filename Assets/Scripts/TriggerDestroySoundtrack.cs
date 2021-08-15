using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDestroySoundtrack : MonoBehaviour
{
    private GameObject soundtrack;

    void Start()
    {
        soundtrack = GameObject.FindGameObjectWithTag("Soundtrack");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(soundtrack);
        }
    }

}

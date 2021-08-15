using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMovingPlataform : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MovingPlataform"))
        {
            Debug.Log("ENTREI!");
            player.transform.parent = other.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MovingPlataform"))
        {
            player.transform.parent = null;
        }
    }
}

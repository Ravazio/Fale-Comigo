using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLoadLevel : MonoBehaviour
{
    public LevelLoaderScript levelLoader;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            levelLoader.LoadNextLevel();
        }
    }
}

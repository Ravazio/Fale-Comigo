using UnityEngine;

public class Door : Interactable
{
    public LevelLoaderScript levelLoader;

    public override void Interact()
    {
        levelLoader.LoadNextLevel();
    }
}

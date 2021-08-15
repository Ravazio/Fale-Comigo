using UnityEngine;

public class MainMenu : MonoBehaviour   
{
    public LevelLoaderScript levelLoader;

    public void PlayGame()
    {
        levelLoader.LoadNextLevel();
        Destroy(GameObject.FindGameObjectWithTag("Soundtrack"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

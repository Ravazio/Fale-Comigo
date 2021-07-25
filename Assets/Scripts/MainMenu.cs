using UnityEngine;

public class MainMenu : MonoBehaviour   
{
    private GameObject soundtrack;
    public LevelLoaderScript levelLoader;

    public void PlayGame()
    {
        levelLoader.LoadNextLevel();
        soundtrack = GameObject.FindGameObjectWithTag("Soundtrack");
        Destroy(soundtrack);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

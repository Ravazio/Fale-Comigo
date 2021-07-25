using UnityEngine.SceneManagement;
using UnityEngine;

public class NextSceneLoader : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

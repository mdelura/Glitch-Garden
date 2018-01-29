using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float autoLoadNextLevelAfter = 0;

    private void Start()
    {
        if (autoLoadNextLevelAfter > 0)
        {
            Invoke(nameof(LoadNextLevel), autoLoadNextLevelAfter);
        }
    }

    public void LoadLevel(string name) => SceneManager.LoadScene(name);

    public void LoadNextLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    public void LoadPreviousLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    public void QuitRequest() => Application.Quit();

}

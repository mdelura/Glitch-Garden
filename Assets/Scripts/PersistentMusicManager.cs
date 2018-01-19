using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentMusicManager : MonoBehaviour
{
    public AudioClip[] sceneClips;

    public float splashScreenDuration = 3;

    private AudioSource _audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += SceneLoaded;
        _audioSource = GetComponent<AudioSource>();
    }

    private void LoadStartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    private void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.buildIndex  > sceneClips.Length - 1 || !sceneClips[scene.buildIndex])
        {
            return;
        }

        _audioSource.Stop();
        _audioSource.clip = sceneClips[scene.buildIndex];

        if (scene.buildIndex == 0)
        {
            Invoke(nameof(LoadStartScene), splashScreenDuration);
        }
        else
        {
            _audioSource.loop = true;
        }

        _audioSource.Play();
    }
}

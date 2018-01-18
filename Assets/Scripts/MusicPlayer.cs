using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer instance = null;

    public float splashScreenDuration = 3;
    public AudioClip splashClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    private AudioSource _music;



    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            SceneManager.sceneLoaded += SceneLoaded;
            DontDestroyOnLoad(gameObject);
            _music = GetComponent<AudioSource>();
            _music.clip = splashClip;
            _music.loop = false;
            _music.Play();
        }
    }

    private void LoadStartScene() => SceneManager.LoadScene("Start");

    private void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        _music.Stop();
        _music.loop = true;

        switch (scene.buildIndex)
        {
            case 0:
                _music.clip = splashClip;
                _music.loop = false;
                Invoke(nameof(LoadStartScene), splashScreenDuration);
                break;
            case 1:
                _music.clip = gameClip;
                break;
            case 2:
                _music.clip = endClip;
                break;
        }

        _music.Play();
    }
}

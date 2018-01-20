using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentMusicManager : MonoBehaviour
{
    public AudioClip[] sceneClips;

    private AudioSource _audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += SceneLoaded;
        _audioSource = GetComponent<AudioSource>();
    }

    private void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        //If sceneClips has not enough items or null items then return immediately
        if (scene.buildIndex > sceneClips.Length - 1 || !sceneClips[scene.buildIndex])
        {
            return;
        }
        _audioSource.Stop();
        _audioSource.clip = sceneClips[scene.buildIndex];
        _audioSource.loop = scene.buildIndex != 0;

        _audioSource.Play();
    }
}

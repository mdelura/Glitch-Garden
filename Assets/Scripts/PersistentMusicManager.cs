using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentMusicManager : MonoBehaviour
{
    public AudioClip[] sceneClips;

    public AudioClip levelCompleteClip;

    private AudioSource _audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += SceneLoaded;
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = Preferences.MasterVolume;

        Preferences.PreferenceChanged += PlayerPrefsManager_PreferenceChanged;
    }

    private void PlayerPrefsManager_PreferenceChanged(PreferenceChangedEventArgs eventArgs)
    {
        if (eventArgs.PreferenceName == nameof(Preferences.MasterVolume))
        {
            _audioSource.volume = (float)eventArgs.Value;
        }
    }

    public void PlayLevelCompleteClip() => PlayClip(levelCompleteClip, false);

    private void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        //If sceneClips has not enough items or null items then return immediately
        if (scene.buildIndex < sceneClips.Length && sceneClips[scene.buildIndex])
        {
            PlayClip(sceneClips[scene.buildIndex], scene.buildIndex != 0);
        }
    }

    private void PlayClip(AudioClip audioClip, bool loop)
    {
        _audioSource.Stop();
        _audioSource.clip = audioClip;
        _audioSource.loop = loop;
        _audioSource.Play();
    }
}

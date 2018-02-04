using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public GameObject levelCompleteMessage;
    public Slider timeLeftSlider;

    public int levelLenghtInSecs = 60;


    private Text _timeText;
    private PersistentMusicManager _musicManager;
    private bool _completed;


    // Use this for initialization
    void Start()
    {
        _timeText = GetComponent<Text>();
        _musicManager = FindObjectOfType<PersistentMusicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _timeText.text = TimeSpan.FromSeconds(TimeLeft).ToString(@"mm\:ss");
        timeLeftSlider.value = Time.timeSinceLevelLoad / levelLenghtInSecs;

        if (TimeLeft <= 0 && 
            !FindObjectOfType<Attacker>() &&
            !_completed)
        {
            _completed = true;
            levelCompleteMessage.SetActive(true);
            _musicManager.PlayLevelCompleteClip();
            Invoke(nameof(LoadNextLevel), 5);
        }
    }

    private void LoadNextLevel() => FindObjectOfType<LevelManager>().LoadNextLevel();

    public int TimeLeft
    {
        get
        {
            int currentTime = Convert.ToInt32(Time.timeSinceLevelLoad);
            if (levelLenghtInSecs < currentTime)
                return 0;
            return levelLenghtInSecs - currentTime;
        }
    }
}

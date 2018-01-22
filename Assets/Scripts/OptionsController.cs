using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider difficultySlider;

    public Text volumeText;
    public Text difficultyText;

    // Use this for initialization
    void Start()
    {
        volumeSlider.value = Preferences.MasterVolume;
        SetVolumeText();
        difficultySlider.value = (int)Preferences.Difficulty;
        SetDifficultyText();
    }

    public void VolumeChanged()
    {
        Preferences.MasterVolume = volumeSlider.value;
        SetVolumeText();
    }

    public void DifficultyChanged()
    {
        Preferences.Difficulty = (Preferences.DifficultyLevel)difficultySlider.value;
        SetDifficultyText();
    }

    public void ResetToDefaults()
    {
        Preferences.ResetUserPrefsToDefaults();
        volumeSlider.value = Preferences.MasterVolume;
        difficultySlider.value = (int)Preferences.Difficulty;
    }

    private void SetVolumeText() => volumeText.text = Mathf.RoundToInt(volumeSlider.value * 100).ToString();

    private void SetDifficultyText() => difficultyText.text = Preferences.Difficulty.ToString();



}

using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Preferences
{
    public enum DifficultyLevel
    {
        Easy = 0,
        Medium = 1,
        Hard = 2

    }

    public static event Action<PreferenceChangedEventArgs> PreferenceChanged;

    public static float MasterVolume
    {
        get { return PlayerPrefs.HasKey(Keys.MasterVolume) ? PlayerPrefs.GetFloat(Keys.MasterVolume) : Defaults.MasterVolume; }
        set
        {
            if (value >= 0f && value <= 1f)
            {
                PlayerPrefs.SetFloat(Keys.MasterVolume, value);
                OnPreferenceChanged(value);
            }
            else Debug.LogError($"Master volume value {value} to be set is out of range (0-1).");
        }
    }

    public static int UnlockedLevel
    {
        get { return PlayerPrefs.GetInt(Keys.UnlockedLevel); }
        set
        {
            if (value <= SceneManager.sceneCountInBuildSettings - 1)
            {
                PlayerPrefs.SetInt(Keys.UnlockedLevel, value);
                OnPreferenceChanged(value);
            }
            else Debug.LogError($"Level index {value} to be set does not exist.");
        }
    }

    public static void ResetUserPrefsToDefaults()
    {
        MasterVolume = Defaults.MasterVolume;
        Difficulty = Defaults.Difficulty;
    }

    public static DifficultyLevel Difficulty
    {
        get { return PlayerPrefs.HasKey(Keys.Difficulty) ? (DifficultyLevel)PlayerPrefs.GetInt(Keys.Difficulty) : Defaults.Difficulty; }
        set
        {
            PlayerPrefs.SetInt(Keys.Difficulty, (int)value);
            OnPreferenceChanged(value);
        }
    }

    private static void OnPreferenceChanged(object value, [CallerMemberName] string preferenceName = null) => PreferenceChanged?.Invoke(new PreferenceChangedEventArgs(preferenceName, value));

    static class Keys
    {
        public const string MasterVolume = "master_volume";
        public const string Difficulty = "difficulty";
        public const string UnlockedLevel = "unlockedLevel";
    }

    static class Defaults
    {
        public const float MasterVolume = 0.5F;
        public const DifficultyLevel Difficulty = DifficultyLevel.Medium;

    }
}

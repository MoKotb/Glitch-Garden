using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string VOLUME_KEY = "volume key";
    const string DIFFICULTY_KEY = "difficulty key";
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 2f;

    public static void SetVolume(float value)
    {
        if (value >= MIN_VOLUME && value <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(VOLUME_KEY, value);
        }
    }

    public static float GetVolume()
    {
        if (PlayerPrefs.GetFloat(VOLUME_KEY) == 0)
        {
            return 0.5f;
        }
        else
        {
            return PlayerPrefs.GetFloat(VOLUME_KEY);
        }
    }

    public static void SetDifficulty(float value)
    {
        if (value >= MIN_DIFFICULTY && value <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, value);
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

}

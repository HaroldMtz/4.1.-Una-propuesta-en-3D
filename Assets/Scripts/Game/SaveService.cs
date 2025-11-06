using UnityEngine;

public static class SaveService
{
    private const string HIGH_SCORE_KEY = "HIGH_SCORE_V1";

    public static int LoadHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
    }

    public static void SaveHighScore(int value)
    {
        int prev = LoadHighScore();
        if (value > prev)
        {
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, value);
            PlayerPrefs.Save();
        }
    }
}

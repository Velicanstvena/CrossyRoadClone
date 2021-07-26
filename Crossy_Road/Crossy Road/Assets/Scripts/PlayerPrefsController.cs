using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string TOTAL_COINS_KEY = "total coins";
    const string HIGH_SCORE_KEY = "high score";

    const int MIN_VALUE = 0;

    public static void SetTotalCoins(int coinsNum)
    {
        if (coinsNum > MIN_VALUE)
        {
            PlayerPrefs.SetInt(TOTAL_COINS_KEY, coinsNum);
        }
    }

    public static int GetTotalCoins()
    {
        return PlayerPrefs.GetInt(TOTAL_COINS_KEY);
    }

    public static void SetHighScore(int highScore)
    {
        if (highScore > MIN_VALUE)
        {
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
        }
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE_KEY);
    }
}

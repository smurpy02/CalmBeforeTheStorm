using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    static int score;

    public static void ResetScore()
    {
        score = 0;
    }

    public static void IncreaseScore(int amount)
    {
        score += amount;
    }

    public static void DecreaseScore(int amount)
    {
        score -= amount;
    }

    public static int GetScore()
    {
        return score;
    }
}

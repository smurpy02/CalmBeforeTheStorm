using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    static int score;
    static int highScore;
    static ScoreKeeper instance;

    public Transform canvas;
    public GameObject scoreBonus;

    void Start()
    {
        instance = this;
    }

    public static void ResetScore()
    {
        score = 0;
    }

    public static void IncreaseScore(int amount)
    {
        score += amount;

        if(score > highScore && !GameManager.isSandbox)
        {
            highScore = score;
        }

        if(amount != 0) Instantiate(instance.scoreBonus, instance.canvas).GetComponentInChildren<TextMeshProUGUI>().text = "+" + amount;
    }

    public static void DecreaseScore(int amount)
    {
        score -= amount;
    }

    public static int GetScore()
    {
        return score;
    }

    public static int GetHighScore()
    {
        return highScore;
    }
}

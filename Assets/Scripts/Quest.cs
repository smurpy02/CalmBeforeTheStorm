using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest : Destructable
{
    public string description;
    public GameObject target;
    public GameObject targetIndicator;
    public int additionalQuestScore;

    public TextMeshProUGUI score;

    public GameObject scoreBonus;

    void Start()
    {
        score.text = "+" + (scoreForDestroying + additionalQuestScore).ToString("0");
    }
}

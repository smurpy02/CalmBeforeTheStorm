using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [Header("Quest Description")]
    public string description;

    [Header("Related Objects")]
    public GameObject target;
    public GameObject targetIndicator;
    public GameObject scoreBonus;

    [Header("Score Stuff")]
    public int additionalQuestScore;
    public Destructable destructable;
    public TextMeshProUGUI score;


    void Start()
    {
        score.text = "+" + (destructable.scoreForDestroying + additionalQuestScore).ToString("0");
    }
}

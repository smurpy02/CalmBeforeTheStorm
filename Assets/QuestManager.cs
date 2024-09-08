using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int maxCurrentQuests;
    public TextMeshProUGUI questText;

    List<Quest> quests;
    List<Quest> currentQuests = new List<Quest>();

    void Start()
    {
        quests = FindObjectsOfType<Quest>().ToList();
        RefreshQuests();
    }

    public void RefreshQuests()
    {
        currentQuests.Clear();

        for (int q = 0; q < maxCurrentQuests; q++)
        {
            AddQuestToCurrent();
        }
    }

    void AddQuestToCurrent()
    {
        if (quests.Count <= 0)
        {
            return;
        }

        Quest quest = quests.First();
        quests.Remove(quest);

        if (quest.target == null)
        {
            AddQuestToCurrent();
            return;
        }

        currentQuests.Add(quest);
    }

    void Update()
    {
        string questString = "Current Score " + ScoreKeeper.GetScore() + "\n";

        Quest[] questsCopy = new Quest[currentQuests.Count];
        currentQuests.CopyTo(questsCopy);

        foreach (Quest quest in questsCopy)
        {
            if (quest != null)
            {
                if (quest.target == null)
                {
                    currentQuests.Remove(quest);
                }
                else
                {
                    questString += quest.description + " | " + quest.scoreForDestroying + "\n";
                    quest.targetIndicator.SetActive(true);
                }
            }
            else
            {
                currentQuests.Remove(quest);
            }
        }

        if (currentQuests.Count <= 0)
        {
            RefreshQuests();
        }

        questText.text = questString;
    }
}

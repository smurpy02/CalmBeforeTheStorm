using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI roundText;
    public GameObject UpgradeUI;
    public MoveCloud cloud;
    public Transform cloudTransform;
    public GameObject rain;
    public GameObject lightning;
    public GameObject flooding;

    public GameObject endPanel;

    public int rounds;
    public float roundTime;

    int round = 1;
    float timer;

    static bool isPlaying = false;

    public static void StopGame()
    {
        isPlaying = false;
    }

    public void StartGame()
    {
        StartNewRound();
    }

    public void StartNewRound()
    {
        isPlaying = true;
        cloud.enabled = true;
        timer = roundTime;
        rain.SetActive(true);
        lightning.SetActive(true);
        flooding.SetActive(true);
    }

    void EndRound()
    {
        isPlaying = false;
        cloud.enabled = false;
        cloud.body.velocity = Vector3.zero;
        rain.SetActive(false);
        lightning.SetActive(false);
        flooding.SetActive(false);

        if (round < rounds)
        {
            round++;
            UpgradeUI.SetActive(true);
            return;
        }

        endPanel.SetActive(true);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, Mathf.Infinity);
        timerText.text = timer.ToString("0.0");
        roundText.text = round + "/" + rounds;

        if (timer <= 0 && isPlaying)
        {
            EndRound();
        }
    }
}

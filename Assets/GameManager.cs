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

    public int rounds;
    public float roundTime;

    int round = 1;
    float timer;

    static bool isPlaying = false;

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
    }

    void EndRound()
    {
        isPlaying = false;
        round++;
        UpgradeUI.SetActive(true);
        cloud.enabled = false;
        cloud.body.velocity = Vector3.zero;
        rain.SetActive(false);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, Mathf.Infinity);
        timerText.text = timer.ToString("0.0");
        roundText.text = round + "/" + rounds;

        if(timer <= 0 && isPlaying)
        {
            EndRound();
        }
    }
}

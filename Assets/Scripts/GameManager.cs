using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI roundText;
    public GameObject UpgradeUI;
    public Transform cloudTransform;

    // STUFF TO DISABLE AND ENABLE
    public GameObject rain;
    public MoveCloud cloud;
    public GameObject upgrades;

    public GameObject endPanel;

    public float gameTime;

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
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        isPlaying = true;
        cloud.enabled = true;
        timer = gameTime;
        rain.SetActive(true);
        upgrades.SetActive(true);
    }

    void EndRound()
    {
        Cursor.visible = true;
        isPlaying = false;
        cloud.enabled = false;
        cloud.body.velocity = Vector3.zero;
        rain.SetActive(false);
        upgrades.SetActive(false);

        endPanel.SetActive(true);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, Mathf.Infinity);
        timerText.text = timer.ToString("0.0");

        if (timer <= 0 && isPlaying)
        {
            EndRound();
        }
    }
}

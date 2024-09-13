using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //SANDBOX STUFF
    bool sandbox = false;
    public static bool isSandbox { get { return FindObjectOfType<GameManager>().sandbox; } }

    public CloudUpgradesManager upgradeManager;
    //--------//

    public TextMeshProUGUI timerText;
    public Transform timerBar;

    // STUFF TO DISABLE AND ENABLE
    public GameObject rain;
    public MoveCloud cloud;
    public GameObject upgrades;

    public GameObject endPanel;
    //--------//

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

        if (sandbox)
        {
            timerText.gameObject.SetActive(false);
            timer = 2000;
            upgradeManager.minSpawnTime = 2;
            upgradeManager.maxSpawnTime = 3;
        }
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
        if(!sandbox) timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, Mathf.Infinity);
        timerText.text = timer.ToString("0.0");
        Vector3 scale = Vector3.one;
        scale.x = timer / gameTime;
        timerBar.localScale = scale;

        if (timer <= 0 && isPlaying)
        {
            EndRound();
        }
    }

    public void SetGameModeSandbox(bool isSandbox)
    {
        sandbox = isSandbox;
    }
}

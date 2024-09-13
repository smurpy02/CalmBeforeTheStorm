using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanelManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void OnEnable()
    {
        scoreText.text = "YOUR SCORE: " + ScoreKeeper.GetScore().ToString("0") + "\nHIGH SCORE: " + ScoreKeeper.GetHighScore().ToString("0");
    }

    public void Retry()
    {
        ScoreKeeper.ResetScore();
        UpgradeManager.upgrades.Clear();
        GameManager.StopGame();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}

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
        scoreText.text = ScoreKeeper.GetScore().ToString("0");
    }

    public void Retry()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLightning : MonoBehaviour
{
    public float minBetweenStrikes;
    public float maxBetweenStrikes;
    public float strikeTime;

    public GameObject lightning;

    void Start()
    {
        StartCoroutine(ToggleLightningStrikes());
    }

    IEnumerator ToggleLightningStrikes()
    {
        float waitTime = Random.Range(0, maxBetweenStrikes - minBetweenStrikes) + minBetweenStrikes;
        yield return new WaitForSeconds(waitTime);

        lightning.SetActive(true);

        yield return new WaitForSeconds(strikeTime);

        lightning.SetActive(false);

        StartCoroutine(ToggleLightningStrikes());
    }
}

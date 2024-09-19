using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LightningPowerup : MonoBehaviour
{
    public float minBetweenStrikes;
    public float maxBetweenStrikes;
    public float strikeTime;

    public GameObject lightning;
    public GameObject lightningParticles;

    void OnEnable()
    {
        StartCoroutine(ToggleLightningStrikes());
    }

    IEnumerator ToggleLightningStrikes()
    {
        float waitTime = Random.Range(0, maxBetweenStrikes - minBetweenStrikes) + minBetweenStrikes;
        yield return new WaitForSeconds(waitTime);

        lightning.SetActive(true);
        Instantiate(lightningParticles, transform.position, transform.rotation);

        yield return new WaitForSeconds(strikeTime);

        lightning.SetActive(false);

        StartCoroutine(ToggleLightningStrikes());
    }
}

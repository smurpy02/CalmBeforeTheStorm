using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public float maxhealth;
    public GameObject healthUI;
    public Transform healthBar;
    public GameObject destroyThis;
    public int scoreForDestroying;
    public GameObject spawnOnDestroy;
    public Transform building;
    public AudioSource damageSound;

    float health;

    void Awake()
    {
        health = maxhealth;
        UpdateHealthBar();
    }

    public void Damage(float damage)
    {
        if (!damageSound.isPlaying)
        {
            damageSound.Play();
        }

        building.DOShakePosition(0.15f, damage * 0.8f);

        health -= damage;

        if (health <= 0) SelfDestruct();

        UpdateHealthBar();
    }

    public void SelfDestruct()
    {
        Instantiate(spawnOnDestroy, transform.position, Quaternion.identity);
        ScoreKeeper.IncreaseScore(scoreForDestroying);
        Destroy(destroyThis);
    }

    void UpdateHealthBar()
    {
        if (healthBar == null || healthUI == null) return;

        healthUI.SetActive(health != maxhealth);

        Vector3 scale = healthBar.localScale;
        scale.x = health / maxhealth;
        healthBar.localScale = scale;
    }
}

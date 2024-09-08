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

    float health;

    void Awake()
    {
        health = maxhealth;
        UpdateHealthBar();
    }

    public void Damage(float damage)
    {
        health -= damage;

        if (health <= 0) SelfDestruct();

        UpdateHealthBar();
    }

    public void SelfDestruct()
    {
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

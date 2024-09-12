using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Upgrade
{
    public string name;
    public string particles;
    public GameObject upgrade;
    public UpgradeBar upgradeBar;
    public float timeLimit;
}

public class CloudUpgradesManager : MonoBehaviour
{
    /* UPGRADE TYPES
     * Larger Cloud - destroy larger area
     * Heavier Rain - does more damage
     * Lightning - lots of damage on single point
     * Flooding - slows evacuation
     * Fire - Does some damage and spreads
     * Hurricane - Increase Speed
    */

    public static CloudUpgradesManager instance;
    public List<Upgrade> upgradesAvailable = new List<Upgrade>();
    public static List<Upgrade> upgrades = new List<Upgrade>();

    public GameObject upgradePickup;
    public float spawnRadius;

    void Start()
    {
        instance = this;
        StartCoroutine(SpawnUpgrades());

        foreach(Upgrade upgrade in upgradesAvailable)
        {
            upgrade.upgradeBar.upgrade = upgrade;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Upgrade upgrade in upgradesAvailable)
        {
            if (upgrade.upgrade != null)
            {
                upgrade.upgrade.SetActive(upgrades.Contains(upgrade));
                upgrade.upgradeBar.gameObject.SetActive(upgrades.Contains(upgrade));
            }
        }
    }

    IEnumerator SpawnUpgrades()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        spawnPosition.y = transform.position.y;

        Instantiate(upgradePickup, spawnPosition, Quaternion.identity);

        yield return new WaitForSeconds(Random.Range(15, 25));

        StartCoroutine(SpawnUpgrades());
    }

    public static void AddUpgrade(Upgrade upgrade)
    {
        upgrades.Add(upgrade);
        upgrade.upgradeBar.gameObject.SetActive(false);
        upgrade.upgradeBar.gameObject.SetActive(true);
    }
}

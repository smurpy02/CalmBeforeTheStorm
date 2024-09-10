using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePickup : MonoBehaviour
{
    Upgrade upgrade;

    // Start is called before the first frame update
    void Start()
    {
        upgrade = CloudUpgradesManager.instance.upgradesAvailable[Random.Range(0, CloudUpgradesManager.instance.upgradesAvailable.Count)];

        foreach(ParticleSystem particles in GetComponentsInChildren<ParticleSystem>(true))
        {
            if(particles.gameObject.name == upgrade.particles)
            {
                particles.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("got upgrade " + upgrade.name);
            CloudUpgradesManager.upgrades.Add(upgrade);
            Destroy(gameObject);
        }
    }
}

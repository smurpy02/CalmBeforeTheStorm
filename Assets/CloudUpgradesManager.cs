using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Transform rainArea;
    public List<Transform> rainParticles;

    public GameObject heavyRainParts;
    public DoDamage rainDamage;
    public float heavyRainDamage;

    public GameObject lightning;

    public GameObject flooding;

    // Update is called once per frame
    void Update()
    {
        if(UpgradeManager.upgrades.Contains("Larger Cloud"))
        {
            Vector3 scale = Vector3.one;
            scale.x = 2;
            scale.z = 2;
            rainArea.transform.localScale = scale;

            foreach(Transform rain in rainParticles)
            {
                rain.localScale = Vector3.Lerp(rain.localScale, Vector3.one * 2, Time.deltaTime);
            }
        }

        if(UpgradeManager.upgrades.Contains("Heavy Rain"))
        {
            heavyRainParts.SetActive(true);
            rainDamage.damage = heavyRainDamage;
        }

        if (UpgradeManager.upgrades.Contains("Lightning"))
        {
            lightning.SetActive(true);
        }

        if (UpgradeManager.upgrades.Contains("Flooding"))
        {
            flooding.SetActive(true);
        }
    }
}

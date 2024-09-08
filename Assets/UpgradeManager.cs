using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    /* UPGRADE TYPES
     * Larger Cloud - destroy larger area
     * Heavier Rain - does more damage
     * Lightning - lots of damage on single point
     * More Lightning - reduce lightning cooldown
     * Flooding - slows evacuation
     * Fire - Does some damage and spreads
     * Hurricane - Increase Speed
    */

    public List<string> allUpgrades; // possible upgrades
    public static List<string> upgrades = new List<string>(); // upgrades bought

    List<string> availableUpgrades = new List<string>(); // upgrades left to buy

    public TextMeshProUGUI upgrade1Text;
    public TextMeshProUGUI upgrade2Text;

    public GameManager gameManager;

    string upgrade1;
    string upgrade2;

    void Awake()
    {
        foreach(string upgrade in allUpgrades)
        {
            availableUpgrades.Add(upgrade);
        }
    }

    void OnEnable()
    {
        if(availableUpgrades.Count < 2)
        {
            if(availableUpgrades.Count == 0)
            {
                StopUpgrading();
                return;
            }
            else
            {
                upgrade1 = availableUpgrades[0];
                upgrade2 = availableUpgrades[0];
            }
        }

        upgrade1 = GetRandomUpgrade();
        upgrade2 = GetRandomUpgrade(upgrade1);

        upgrade1Text.text = upgrade1;
        upgrade2Text.text = upgrade2;
    }

    string GetRandomUpgrade(string exclude = null)
    {
        int upgrade = Random.Range(0, availableUpgrades.Count);

        if(exclude == availableUpgrades[upgrade])
        {
            return GetRandomUpgrade();
        }

        return (availableUpgrades[upgrade]);
    }

    public void GetUpgrade1()
    {
        availableUpgrades.Remove(upgrade1);
        upgrades.Add(upgrade1);

        StopUpgrading();
    }

    public void GetUpgrade2()
    {
        availableUpgrades.Remove(upgrade2);
        upgrades.Add(upgrade2);

        StopUpgrading();
    }

    void StopUpgrading()
    {
        upgrade1 = "";
        upgrade2 = "";

        upgrade1Text.text = "";
        upgrade2Text.text = "";

        gameObject.SetActive (false);
        gameManager.StartNewRound();
    }
}

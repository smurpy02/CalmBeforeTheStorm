using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeBar : MonoBehaviour
{
    public Upgrade upgrade;

    public TextMeshProUGUI text;
    public Transform bar;

    float time=1;

    void OnEnable()
    {
        time = upgrade.timeLimit;
        text.text = upgrade.name;
    }

    void Update()
    {
        time -= Time.deltaTime;

        if(time < 0)
        {
            CloudUpgradesManager.upgrades.Remove(upgrade);
        }

        Vector3 scale = Vector3.one;
        scale.x = time / upgrade.timeLimit;
        bar.localScale = scale;
    }
}

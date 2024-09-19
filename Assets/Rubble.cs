using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubble : DestroyAfterTime
{
    void Awake()
    {
        time = RubbleLagManager.instance.killTime;
        RubbleLagManager.rubble.Add(gameObject);
    }
}

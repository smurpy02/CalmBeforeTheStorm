using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLightningStrikes : MonoBehaviour
{
    public GameObject spawn;

    void OnEnable()
    {
        Instantiate(spawn, transform.position, transform.rotation);
    }
}

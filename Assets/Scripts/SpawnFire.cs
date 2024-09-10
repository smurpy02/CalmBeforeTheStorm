using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFire : MonoBehaviour
{
    public GameObject fire;

    void OnTriggerEnter(Collider other)
    {
        Destructable destructable = other.GetComponent<Destructable>();

        if (destructable != null)
        {
            for (int i = 0; i < Random.Range(1, 3); i++)
            {
                Vector3 spawnPosition = other.transform.position;
                spawnPosition.y += other.transform.localScale.y / 2;

                Vector3 randomOffset = Random.insideUnitSphere;
                randomOffset.y = 0;
                randomOffset.x *= other.transform.localScale.x / 2;
                randomOffset.z *= other.transform.localScale.z / 2;

                spawnPosition += randomOffset;

                Instantiate(fire, spawnPosition, Quaternion.identity, other.transform);
            }

        }
    }
}

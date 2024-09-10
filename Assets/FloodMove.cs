using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodMove : MonoBehaviour
{
    List<Transform> flooded = new List<Transform>();

    void OnTriggerEnter(Collider other)
    {
        Destructable d = other.GetComponent<Destructable>();
        Transform t;

        if (d != null)
        {
            t = d.destroyThis.transform;
        }
        else
        {
            return;
        }

        if (!flooded.Contains(t))
        {
            flooded.Add(t);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Destructable d = other.GetComponent<Destructable>();
        Transform t;

        if(d != null)
        {
            t = d.destroyThis.transform;
        }
        else
        {
            return;
        }

        if (flooded.Contains(t))
        {
            flooded.Remove(t);
        }
    }

    void Update()
    {
        foreach (Transform building in flooded)
        {
            if (building == null)
            {
                // do nothing
            }
            else
            {
                Vector3 targetPosition = transform.position;
                targetPosition.y = building.position.y;

                building.transform.position = Vector3.MoveTowards(building.transform.position, targetPosition, Time.deltaTime * 4f);
            }
        }
    }
}

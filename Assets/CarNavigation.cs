using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarNavigation : MonoBehaviour
{
    public NavMeshAgent agent;

    public float travelDistance;

    void Start()
    {
        StartCoroutine(GoPlaces());
    }

    IEnumerator GoPlaces()
    {
        Vector3 position = transform.position + Random.insideUnitSphere * travelDistance;
        position.y = transform.position.y;

        NavMeshPath path = new NavMeshPath();

        agent.SetDestination(position);

        while (agent.velocity != Vector3.zero)
        {
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.1f);

        StartCoroutine(GoPlaces());

    }
}

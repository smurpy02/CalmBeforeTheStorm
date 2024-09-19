using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float time;

    void Start()
    {
        StartCoroutine(TimedDestroy());
    }

    IEnumerator TimedDestroy()
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}

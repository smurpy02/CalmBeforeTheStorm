using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBonus : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        transform.position += (Vector3)Random.insideUnitCircle * 25;

        StartCoroutine(ShakeAndDie());
    }

    IEnumerator ShakeAndDie()
    {
        yield return transform.DOMoveY(transform.position.y-60, Random.Range(0.45f, 0.65f)).WaitForCompletion();

        Destroy(gameObject);
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Anim());
    }

    IEnumerator Anim()
    {
        yield return transform.DOScale(Vector3.one, 0.5f).WaitForCompletion();
        yield return new WaitForSeconds(3f);
        transform.DOScale(Vector3.zero, 0.4f);
    }
}

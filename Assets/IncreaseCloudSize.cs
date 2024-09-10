using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseCloudSize : MonoBehaviour
{
    public List<Transform> enlarge;

    void OnEnable()
    {
        foreach(Transform t in enlarge)
        {
            t.DOScaleX(t.localScale.x * 2, 1);
            t.DOScaleZ(t.localScale.z * 2, 1);
            t.DOScaleY(t.localScale.y * 1.5f, 1);
        }
    }
    void OnDisable()
    {
        foreach(Transform t in enlarge)
        {
            t.DOScaleX(t.localScale.x / 2, 1);
            t.DOScaleZ(t.localScale.z / 2, 1);
            t.DOScaleY(t.localScale.y / 1.5f, 1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoFlickering : MonoBehaviour
{
    public SpriteRenderer _renderer;

    Color baseColor;

    void Start()
    {
        baseColor = _renderer.color;
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        yield return new WaitForSeconds(Random.Range(0.2f, 0.6f));

        Color color = baseColor;
        color.r += 10;
        color.g += 10;
        color.b += 10;
        _renderer.color = color;

        yield return new WaitForSeconds(0.1f);

        _renderer.color = baseColor;

        StartCoroutine(Flash());
    }
}

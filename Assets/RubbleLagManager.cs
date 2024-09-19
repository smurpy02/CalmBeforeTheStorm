using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RubbleLagManager : MonoBehaviour
{
    public static RubbleLagManager instance;
    public static List<GameObject> rubble = new List<GameObject>();

    public float killTime; // rubble is always destroyed after this max time
    public int lowerRubbleLimit; // start destroying rubble over this limit
    public float cooldownBetweenDestroying; // time between destroying rubble (ignored above upper limit)
    public int upperRubbleLimit; // instantly remove all rubble over limit

    float timer = 0;

    List<GameObject> debugRubble;

    void Start()
    {
        if(instance == null) instance = this;
    }

    void Update()
    {
        if(instance != this)
        {
            return;
        }

        debugRubble = rubble;

        timer += Time.deltaTime;

        if(rubble.Count > lowerRubbleLimit && timer >= cooldownBetweenDestroying)
        {
            timer = 0;
            GameObject rubbleToDestroy = rubble.First();
            StartCoroutine(DestroyRubbleFancy(rubbleToDestroy));
        }

        if(rubble.Count > upperRubbleLimit)
        {
            int count = 0;

            GameObject[] rubbles = rubble.ToArray();

            foreach(GameObject rubbleToDestroy in rubbles)
            {
                if(count <= rubble.Count - upperRubbleLimit)
                {
                    DestroyRubble(rubbleToDestroy);
                }

                count++;
            }
        }
    }

    IEnumerator DestroyRubbleFancy(GameObject rubbleToDestroy)
    {
        Debug.Log("destroying rubble FANCY " + rubbleToDestroy);
        yield return rubbleToDestroy.transform.DOScale(Vector3.zero, 0.7f).WaitForCompletion();
        Debug.Log("scaling finished");

        DestroyRubble(rubbleToDestroy);
    }

    void DestroyRubble(GameObject rubbleToDestroy)
    {
        Debug.Log("Destroying Rubble " + rubbleToDestroy);
        rubble.Remove(rubbleToDestroy);
        Destroy(rubbleToDestroy);
    }
}

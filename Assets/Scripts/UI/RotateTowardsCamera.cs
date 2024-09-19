using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsCamera : MonoBehaviour
{
    Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
    }

    void Update()
    {
        Vector3 forward = cam.position - transform.position;
        forward.y = 0;

        transform.rotation = Quaternion.LookRotation(forward);
    }
}

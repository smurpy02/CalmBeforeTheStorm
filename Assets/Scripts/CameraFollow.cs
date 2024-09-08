using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraFollowPoint;
    public float followDistance;

    void Update()
    {
        Vector3 playerPosition = cameraFollowPoint.position;
        Vector3 position = transform.position;

        playerPosition.y = position.y;

        transform.rotation = cameraFollowPoint.rotation;
        transform.position = Vector3.Lerp(position, playerPosition, Time.deltaTime * 0.8f);
    }
}

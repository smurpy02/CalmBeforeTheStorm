using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraFollowPoint;
    public Transform cameraPivot;
    public float followDistance;
    public InputActionReference move;

    void Update()
    {
        Vector3 playerPosition = cameraFollowPoint.position;
        Vector3 position = transform.position;

        playerPosition.y = position.y;

        transform.rotation = cameraFollowPoint.rotation;
        transform.position = Vector3.Lerp(position, playerPosition, Time.deltaTime * 1f);

        Vector2 movement = move.action.ReadValue<Vector2>();

        cameraPivot.rotation = Quaternion.Lerp(cameraPivot.rotation, Quaternion.Euler(0, movement.x * 20f, 0), Time.deltaTime);
    }
}

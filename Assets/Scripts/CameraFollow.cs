using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraFollowPoint;
    public Transform cameraPivot;
    public Transform cameraTransform;

    public float followDistance;
    public float mouseSensitivity;
    public float freeViewZoomScale;

    public InputActionReference move;
    public InputActionReference freeview;
    public InputActionReference mouseAxis;

    Vector3 rotation = Vector3.zero;
    Vector3 cameraLocalPosition;

    void Start()
    {
        cameraLocalPosition = cameraTransform.localPosition;
    }

    void Update()
    {
        Vector3 playerPosition = cameraFollowPoint.position;
        Vector3 position = transform.position;

        playerPosition.y = position.y;

        transform.rotation = cameraFollowPoint.rotation;
        transform.position = Vector3.Lerp(position, playerPosition, Time.deltaTime * 5f);

        Vector2 movement = move.action.ReadValue<Vector2>();

        Vector3 rotationOffset = Vector3.zero;
        rotationOffset.y = Mathf.Lerp(rotationOffset.y, movement.x * 20f, Time.deltaTime * 2);
        cameraPivot.rotation = Quaternion.Euler(rotation + rotationOffset);

        Vector3 cameraTargetPosition = cameraLocalPosition;

        float delta = -mouseAxis.action.ReadValue<Vector2>().x;

        if (delta != 0)
        {
            rotation.y -= delta * Time.deltaTime * mouseSensitivity;
            cameraTargetPosition = cameraLocalPosition * freeViewZoomScale;
        }
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, cameraTargetPosition, Time.deltaTime * 2);
    }
}

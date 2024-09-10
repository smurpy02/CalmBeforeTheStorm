using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MoveCloud : MonoBehaviour
{
    public float speed;
    public float hurricaneSpeed;
    public InputActionReference move;
    public Rigidbody body;
    public Transform cameraPivot;
    public GameObject hurricaneUpgrade;

    void Update()
    {
        float currentSpeed = hurricaneUpgrade.activeSelf ? hurricaneSpeed : speed;

        Vector2 movement = move.action.ReadValue<Vector2>();
        Vector3 velocity = Vector3.zero;

        velocity += movement.x * cameraPivot.right;
        velocity += movement.y * cameraPivot.forward;

        body.velocity = velocity * currentSpeed;
    }
}

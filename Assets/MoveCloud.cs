using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MoveCloud : MonoBehaviour
{
    public float speed;
    public InputActionReference move;
    public Rigidbody body;
    
    void Update()
    {
        Vector2 movement = move.action.ReadValue<Vector2>();
        Vector3 velocity = Vector3.zero;

        velocity.x = movement.x;
        velocity.z = movement.y;

        body.velocity = velocity * speed;
    }
}

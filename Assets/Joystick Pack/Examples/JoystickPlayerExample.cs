using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public FixedJoystick fixedJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (fixedJoystick.Horizontal > 0.3f || fixedJoystick.Vertical > 0.3f)
            rb.velocity = (Vector3.forward * fixedJoystick.Vertical + Vector3.right * fixedJoystick.Horizontal) * speed;
    }
}
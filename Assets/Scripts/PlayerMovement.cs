using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public FixedJoystick fixedJoystick;
    public Rigidbody rb;
    Vector3 movement = new Vector3();

    public void FixedUpdate()
    {
        //Move();
        MoveKeyboard();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(fixedJoystick.Horizontal, 0, fixedJoystick.Vertical);
        rb.velocity = movement.normalized * speed;

        if (fixedJoystick.Horizontal != 0 || fixedJoystick.Vertical != 0)
            transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    private void MoveKeyboard()
    {
        if (Input.GetKeyDown("w"))
        {
            movement = Vector3.forward;
        }
        if (Input.GetKeyDown("d"))
        {
            movement = Vector3.right;
        }
        if (Input.GetKeyDown("s"))
        {
            movement = -Vector3.forward;
        }
        if (Input.GetKeyDown("a"))
        {
            movement = -Vector3.right;
        }

        rb.velocity = movement.normalized * speed;
        if (rb.velocity != new Vector3(0, 0, 0))
            transform.rotation = Quaternion.LookRotation(rb.velocity);
    }
}

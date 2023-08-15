using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public FixedJoystick moveJoystick;
    public FixedJoystick fireJoystick;
    public Rigidbody rb;
    Vector3 movement = new Vector3();

    public void FixedUpdate()
    {
        Move();
        //MoveKeyboard();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(moveJoystick.Horizontal, 0, moveJoystick.Vertical);
        rb.velocity = movement.normalized * speed;

        if (moveJoystick.Horizontal != 0 || moveJoystick.Vertical != 0)
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

        if (rb.velocity != new Vector3(0, 0, 0) && (fireJoystick.Horizontal == 0 || fireJoystick.Vertical == 0))
            transform.rotation = Quaternion.LookRotation(rb.velocity);
    }
}

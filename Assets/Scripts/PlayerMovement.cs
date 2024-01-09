using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public float speed = 1f;
    public Rigidbody rb;
    public Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        movement = new Vector3(joystick.Horizontal, 0, joystick.Vertical).normalized;

        moveCharacter(movement);

        Rotate();
    }

    void moveCharacter(Vector3 direction)
    {
        rb.velocity = direction * speed;
    }

    void Rotate()
    {
        // Get the direction of movement
        Vector3 movementDirection = rb.velocity.normalized;

        if (movementDirection != Vector3.zero)
        {
            // Create a rotation that looks in the direction of movement
            Quaternion rotation = Quaternion.LookRotation(movementDirection);

            // Rotate the Rigidbody towards the direction of movement
            rb.MoveRotation(rotation);
        }
    }
}

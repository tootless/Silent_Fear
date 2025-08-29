using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour
{
    /// MOVE ON X AXIS
    /// JUMP ON Y AXIS, CAN MOVE MIDAIR
    /// JUMP BIG AFTER T SECONDS HOLDING

    Rigidbody rb;

    [Range(0f, 20f)]
    [SerializeField] float runSpeed = 1f;

    [Range(0f, 500f)]
    [SerializeField] float jumpPower = 10f;

    [Range(0f, 40f)]
    [SerializeField] float fallPower = 10f;

    [SerializeField] float bigJumpChargeTime = 1.5f;

    public bool isGrounded = true;
    public bool canJump = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var inputX = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            }
        }
        if (!isGrounded) rb.AddForce(new Vector3(0, -fallPower, 0), ForceMode.Acceleration);

        rb.velocity = new Vector2(inputX, 0);

        rb.velocity.Normalize();

        if (Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            Debug.Log("Something hit!");
            isGrounded = true;
        }
    }

}

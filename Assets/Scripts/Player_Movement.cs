using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player_Movement : MonoBehaviour
{

    [SerializeField]
    private Rigidbody rb;
    public Transform orientation;

    [Header("Ground Check")]
    [SerializeField]
    private float playerHeight;
    [SerializeField]
    private LayerMask whatIsGround;
    public bool grounded;

    [Header("Movement")]
    [SerializeField]
    private float _moveSpeed;
    public float groundDrag;

    [Header("Jumping")]
    [SerializeField]
    private float _jumpForce;

    private Vector2 _moveInput;
    private Vector3 _moveDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        SpeedControl();
        if (grounded)
        {
            rb.linearDamping = groundDrag;
        }
        else
        {
            rb.linearDamping = 0;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (grounded && context.performed)
        {
            rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        _moveDirection = orientation.forward * _moveInput.y + orientation.right * _moveInput.x;
        rb.linearVelocity = new Vector3(_moveDirection.x * _moveSpeed, rb.linearVelocity.y, _moveDirection.z * _moveSpeed);
    }

    public void Moving(InputAction.CallbackContext context)
    {
        _moveInput = context.action.ReadValue<Vector2>();
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        //limit vel
        if(flatVel.magnitude > _moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * _moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }
}

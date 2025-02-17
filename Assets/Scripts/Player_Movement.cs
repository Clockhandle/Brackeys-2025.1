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

    public InputActionReference moveAction;
    public InputActionReference jumpAction;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        _moveInput = moveAction.action.ReadValue<Vector2>();

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

    private void OnEnable()
    {
        jumpAction.action.started += Jump;
        jumpAction.action.Enable();
    }

    private void OnDisable()
    {
        jumpAction.action.started -= Jump;
        jumpAction.action.Disable();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (grounded)
        {
            rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        _moveDirection = orientation.forward * _moveInput.y + orientation.right * _moveInput.x;
        rb.linearVelocity = new Vector3(_moveDirection.x * _moveSpeed, rb.linearVelocity.y, _moveDirection.z * _moveSpeed);
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

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player_Movement : MonoBehaviour
{

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float _moveSpeed;

    private Vector2 _moveDirection;

    public InputActionReference moveAction;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _moveDirection = moveAction.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(_moveDirection.x * _moveSpeed, 0,  _moveDirection.y * _moveSpeed);
    }
}

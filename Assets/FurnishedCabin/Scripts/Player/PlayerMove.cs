using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    private Vector2 moveInput;

    [SerializeField] private float movementSpeed = 2f;

    private CharacterController charController;


    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    public void OnMovementInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void PlayerMovement()
    {
        Vector3 forwardMovement = moveInput.y * transform.forward;
        Vector3 rightMovement = moveInput.x *  transform.right;

        //simple move applies delta time automatically
        charController.SimpleMove((forwardMovement + rightMovement).normalized * movementSpeed);
    }
}

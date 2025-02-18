using UnityEngine;
using UnityEngine.InputSystem;

public class First_Person_Camera : MonoBehaviour
{
    [Header("Reference")]

    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;
    public float rotationSpeed;

    [Header("InputAction")]
    private Vector2 _moveDirection;
    public InputActionReference moveAction;
    public InputActionReference mouseAction;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
    // Update is called once per frame
    void Update()
    {
        // Get the forward direction from the camera (since this script is on the camera)
        Vector3 viewDir = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;

        // Rotate the player to match the camera's forward direction
        player.transform.forward = viewDir;

        Debug.DrawRay(orientation.transform.position, orientation.transform.forward * 2f, Color.red);
        // Ensure orientation matches the player's forward direction
        orientation.forward = player.transform.forward;

        // Calculate movement direction relative to the player's facing direction
        _moveDirection = moveAction.action.ReadValue<Vector2>();
        Vector3 inputDir = orientation.forward * _moveDirection.y + orientation.right * _moveDirection.x;

        if (inputDir != Vector3.zero )
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
    }
}

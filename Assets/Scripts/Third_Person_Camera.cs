using UnityEngine;
using UnityEngine.InputSystem;

public class Third_Person_Camera : MonoBehaviour
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
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        //rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        //rotate player object
        _moveDirection = moveAction.action.ReadValue<Vector2>();
        Vector3 inputDir = orientation.forward * _moveDirection.y + orientation.right * _moveDirection.x;

        if(inputDir != Vector3.zero )
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
    }
}

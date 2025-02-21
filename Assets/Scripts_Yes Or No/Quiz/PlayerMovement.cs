using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float turnSpeed = 10;

    private void Start()
    {
        
    }
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * vertical* 10);
        //   transform.Translate(-Vector3.right * Time.deltaTime * horizontal);  

        transform.Rotate(Vector3.up * horizontal * turnSpeed * Time.deltaTime);
    }
}

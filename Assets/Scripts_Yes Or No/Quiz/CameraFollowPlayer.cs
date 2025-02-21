using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject cube;

    private void Update()
    {
        transform.position = cube.transform.position + new Vector3(0,2,-5);   
    }
}

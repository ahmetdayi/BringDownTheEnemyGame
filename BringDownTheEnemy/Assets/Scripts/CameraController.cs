using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotateSpeed =40f;
   

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        float horizontalValue = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotateSpeed * (Time.deltaTime * horizontalValue));
    }
}

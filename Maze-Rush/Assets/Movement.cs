using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 moveDir;
    public float moveSpeed = 5f;

    public Vector3 bodyRotate;
    public float rotateSpeed = 200f;

    public Transform cam;
    public Vector3 camRotate;

    void Update()
    {
        // Movement
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");
        transform.Translate(moveDir * Time.deltaTime * moveSpeed, Space.World);

        // Body Rotation (Left/Right with Mouse X)
        bodyRotate.y = Input.GetAxis("Mouse X");
        transform.Rotate(bodyRotate * Time.deltaTime * rotateSpeed);

        // Camera Rotation (Up/Down with Mouse Y)
        if (cam != null)
        {
            camRotate.x = -Input.GetAxis("Mouse Y");
            cam.Rotate(camRotate * Time.deltaTime * rotateSpeed);
        }
    }
}
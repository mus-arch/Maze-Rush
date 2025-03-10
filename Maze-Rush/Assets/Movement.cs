using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 moveDir;
    public float moveSpeed;
    public Vector3 bodyrotate;
    public float rotateSpeed;

    public Transform cam;
    public Vector3 camrotate;



    void Start()
    {

    }


    void Update()
    {

        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");
        transform.Translate(moveDir * Time.deltaTime * moveSpeed);

        camrotate.x = -Input.GetAxis("Mouse Y");
        bodyrotate.y = Input.GetAxis("Mouse X");

        transform.Rotate(bodyrotate * Time.deltaTime * rotateSpeed);
        cam.Rotate(camrotate * Time.deltaTime * rotateSpeed);
    }
}
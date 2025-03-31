using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 moveDir;
    public float moveSpeed;
    public Vector3 bodyRotate;
    public float rotateSpeed;
    public Transform cam;
    public Vector3 camRotate;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");
        transform.Translate(moveDir * Time.deltaTime * moveSpeed);

        bodyRotate.y = Input.GetAxis("Mouse X");
        transform.Rotate(bodyRotate * Time.deltaTime * rotateSpeed);

        camRotate.x = -Input.GetAxis("Mouse Y");
        cam.Rotate(camRotate * Time.deltaTime * rotateSpeed);
    }
}
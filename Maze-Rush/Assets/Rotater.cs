using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rotater : MonoBehaviour
{
    public Vector3 rotateDir;
    public float mouseX;
    public float mouseY;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateDir * Time.deltaTime);
        print(Time.deltaTime);
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        print(mouseX);
        print(mouseY);
    }
}
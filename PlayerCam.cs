using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // Player senitivity variables 
    public float sensX;
    public float sensY;

    public Transform orientation;

    // Player rotation variables 
    float xRotation;
    float yRotation;

    private void Start()
    {
        //sets cursor to stay on screen and makes it invisable
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        
        yRotation += mouseX;
        xRotation -= mouseY;

        //makes sure camera does not rotate too much
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate cam and orientation 
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}

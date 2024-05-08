using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    float inputCameraX;
    public float mouseSensitivity = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        inputCameraX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(Vector3.up * inputCameraX);
    }
}

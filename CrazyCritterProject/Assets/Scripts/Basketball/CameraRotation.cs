using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    Camera Camera;
    void Start()
    {
        Camera = GetComponentInChildren<Camera>();
    }
    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        transform.localRotation = Quaternion.Euler(0, mouseX, 0) * transform.localRotation;
        
        Camera.transform.localRotation = Quaternion.Euler(-mouseY, 0, 0) * Camera.transform.localRotation;
    }
}

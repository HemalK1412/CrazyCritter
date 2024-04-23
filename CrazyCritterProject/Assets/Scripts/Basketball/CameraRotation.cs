using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    Camera Camera;

    [SerializeField] private float maxAngle = 90;
    
    private float xRotation = 0.0f;
    void Start()
    {
        Camera = GetComponentInChildren<Camera>();
    }
    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        transform.localRotation = Quaternion.Euler(0, mouseX, 0) * transform.localRotation;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxAngle, maxAngle);
        
        //xRotation = Mathf.Clamp(xRotation, -maxAngle, maxAngle);
        Camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        
    }
}

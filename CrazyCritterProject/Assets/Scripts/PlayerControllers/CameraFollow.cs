using UnityEngine;
/*
public class CameraOrbit : MonoBehaviour
{
    public Transform player_Cameraoffset;
    public Vector3 offset = new Vector3(0, 5, -10);

    private void LateUpdate()
    {
        
    }


    
    private void LateUpdate()
    {
        // Calculate the new position of the camera
        Vector3 newPosition = player.position + player.rotation * offset;
        transform.position = newPosition;

        // Rotate the camera to look at the player
        transform.LookAt(player);
    }
    
}
*/

public class CameraOrbit : MonoBehaviour
{
    public Transform target;
    float speed = 5f;
    public float rotationSpeed = 5f;
    public float lerpDuration = 2f;

    private Vector3 startPosition; 
    private Quaternion startRotation; 
    private Vector3 targetPosition; 
    private float timeElapsed;

    private void Start()
    {
        // Set the start position and rotation to the current position and rotation
        startPosition = transform.position; startRotation = transform.rotation;

        // Set the target position to the target object's position
        targetPosition = target.position;

        // Reset the time elapsed
        timeElapsed = 0f;
    }

    private void Update()
    {
        // Calculate the lerp position and rotation
        float t = timeElapsed / lerpDuration; 
        Vector3 newPosition = Vector3.Lerp(startPosition, targetPosition, t); 
        Quaternion newRotation = Quaternion.Lerp(startRotation, target.rotation, t);
        // Move and rotate towards the target position and rotation
        transform.position = newPosition; transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        // Increase the time elapsed
        timeElapsed += Time.deltaTime;
        // If the lerp is complete, set the start position and rotation to the new position and rotation
        if (t >= 1f) 
        { 
            startPosition = newPosition; startRotation = newRotation;

            // Set the new target position to a random position within a certain radius
            targetPosition = target.position + Random.insideUnitSphere * 5f;

            // Reset the time elapsed
            timeElapsed = 0f; 
        }

        // Look at the target object
        transform.LookAt(target); 
    } 
}
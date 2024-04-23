using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    /*
    public Transform player_Cameraoffset;
    public float speed;
    */
    public Transform player;

    public Vector3 offset = new Vector3(0, 5, -10);

    private void LateUpdate()
    {
        
        // Calculate the new position of the camera
        Vector3 newPosition = player.position + player.rotation * offset;
        transform.position = newPosition;

        // Rotate the camera to look at the player
        transform.LookAt(player);
        
        /*
        transform.position = Vector3.Lerp(transform.position, player_Cameraoffset.position, speed * Time.deltaTime);

        transform.LookAt(Player);
        */
    }
    
}
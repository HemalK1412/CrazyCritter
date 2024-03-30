using UnityEngine;

public class Ground : MonoBehaviour
{
    public SpawnerFinalized spawnerFinalized;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Nuts"))
        {
            spawnerFinalized.objectsSpawned--;

            Destroy (collision.gameObject, 3.0f);

            
        }
    }
}

using UnityEngine;

public class Ground : MonoBehaviour
{
    SpawnerFinalized spawnerFinalized;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Nuts"))
        {
            Destroy (collision.gameObject, 3.0f);

            spawnerFinalized.objectsSpawned--;
        }
    }
}

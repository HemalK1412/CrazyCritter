using UnityEngine;

public class Ground : MonoBehaviour
{
    public Spawner spawnerFinalized;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Nuts"))
        {
            spawnerFinalized.NutsSpawned--;

            Destroy (collision.gameObject, 3.0f);

            
        }
    }
}

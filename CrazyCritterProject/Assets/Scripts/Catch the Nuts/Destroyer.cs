using UnityEngine;

public class Destroyer : MonoBehaviour
{
    SpawnerFinalized SpawnerFinalized;
    private void OnCollisionEnter(Collision collider)
    {
        Destroy(collider.gameObject);
        SpawnerFinalized.objectsSpawned--;
        
    }
}

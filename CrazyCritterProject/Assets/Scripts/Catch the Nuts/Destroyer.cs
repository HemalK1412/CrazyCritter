using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public SpawnerFinalized SpawnerFinalized;
    private void OnCollisionEnter(Collision collider)
    {
        SpawnerFinalized.objectsSpawned--;

        Destroy(collider.gameObject);
        
    }
}

using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public Spawner SpawnerFinalized;
    private void OnCollisionEnter(Collision collider)
    {
        SpawnerFinalized.NutsSpawned--;

        Destroy(collider.gameObject);
        
    }
}

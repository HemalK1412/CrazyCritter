using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Collider spawnArea;
    public GameObject Nutprefab;

    public int numObjectsToSpawn = 10;
    public int NutsSpawned = 0;

    private void Update()
    {
        //objectsSpawned = GameObject.FindObjectsOfType<Nuts>().Length;
        if (NutsSpawned <= numObjectsToSpawn)
        {
            Vector3 SpawnPosition = GetRandomPosition();

            Instantiate(Nutprefab, SpawnPosition, Random.rotation);
            NutsSpawned ++;
        }
    }


    Vector3 GetRandomPosition()
    {
        Vector3 randomPos = new Vector3(
                Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
                Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
            );
        return randomPos;
    }
}
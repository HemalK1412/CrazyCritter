using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public Collider spawnArea;
    public GameObject NutPrefab;

    public float spawnDuration = 60;

    public int numObjectsToSpawn = 10;
    public int objectsSpawned = 0;

    private void Update()
    { if (Input.GetKey("h"))
        {
            StartCoroutine(SpawnNuts());

        }
    }

    private IEnumerator SpawnNuts()
    {
        float elapsedTime = 0;

        while (objectsSpawned < numObjectsToSpawn)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
                Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
            );

            Instantiate(NutPrefab, spawnPosition, Random.rotation);

            objectsSpawned++;

            yield return new WaitForSeconds(0.1f);

            elapsedTime += Time.deltaTime;

            if (elapsedTime >= spawnDuration)
            {
                StopCoroutine(SpawnNuts());
            }
        }
    }
}
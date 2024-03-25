using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trial : MonoBehaviour
{
    // Collider for spawning inside
    public Collider spawnArea;
    // Prefab for spawning
    public GameObject Nuts;
    // Number of objects to spawn
    public int spawnCount = 10;

    // Start function
    void FixedUpdate()
    {
        // Press key to start
        if (Input.GetKey("v"))
        {
            Spawn();
        }
    }

    // Function for spawning
    public void Spawn()
    {
        // Spawn specified amount of objects
        for (int i = 0; i < spawnCount; i++)
        {

            // Get random position within the collider
            Vector3 spawnPos = new Vector3();
            spawnPos.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            spawnPos.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            spawnPos.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

            // Spawn object
            Instantiate(Nuts, spawnPos ,Random.rotation);

            // Set object to not be a child of the spawner
            //obj.transform.SetParent(null);

        }
    }
} 
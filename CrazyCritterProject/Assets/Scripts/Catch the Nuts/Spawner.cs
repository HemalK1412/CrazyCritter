using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trial : MonoBehaviour
{
    public Collider spawnArea;
    public GameObject Nuts;
    public int spawnCount = 10;

    // Start function
    void FixedUpdate()
    {
        if (Input.GetKey("v"))
        {
            Spawn();
        }
    }

    // Function for spawning
    public void Spawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {

            Vector3 spawnPos = new Vector3();
            spawnPos.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            spawnPos.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            spawnPos.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

            Instantiate(Nuts, spawnPos ,Random.rotation);

            // Set object to not be a child of the spawner
            //obj.transform.SetParent(null);

        }
    }
} 
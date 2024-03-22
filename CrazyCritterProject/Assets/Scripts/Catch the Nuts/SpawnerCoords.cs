using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerCoords : MonoBehaviour
{

    [SerializeField] BoxCollider col;
    public float CollisioncheckRadius;
    public int objectcount;


    [SerializeField] GameObject Nuts;
    [SerializeField] GameObject Rocks;

    private void Awake()
    {
    }
    void Start()
    {
        
        
    }

    void Update()
    {

        for (int i = 0; i < objectcount; i++)
        {
            /*
            Vector3 Spawnpoint = GetRandomPosition();
            if (!Physics.CheckSphere(Spawnpoint, CollisioncheckRadius))
            {
                Debug.Log("Check Spawns");
                Instantiate(Nuts, Spawnpoint, Random.rotation);
            }
            */

            Vector3 Spawnpoint = GetRandomPosition();

            Instantiate(Nuts, Spawnpoint, Random.rotation);
        }

    }

    void Spawn()
    {
        /*
        for (int i = 0; i < objectcount; i++)
        {
            Vector3 Spawnpoint = GetRandomPosition();
            if (!Physics.CheckSphere(GetRandomPosition(), CollisioncheckRadius))
            {
                Debug.Log("Check Spawns");
                Instantiate(Nuts, Spawnpoint, Random.rotation);
            }
        }
        */
    }


    public Vector3 GetRandomPosition()
    {
        Vector3 centre = col.center + transform.position;

        float minX = centre.x - col.size.x / 2f;
        float maxX = centre.x + col.size.x / 2f;

        float minY = centre.y - col.size.y / 2f;
        float maxY = centre.y + col.size.y / 2f;

        float minZ = centre.z - col.size.z / 2f;
        float maxZ = centre.z + col.size.z / 2f;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);

        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);
        return randomPosition;
    }

}

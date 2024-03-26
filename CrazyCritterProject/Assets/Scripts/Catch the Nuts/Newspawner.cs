using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspawner : MonoBehaviour
{

    public static Newspawner Instance;
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] Collider spawnArea;

    public Vector3 GetRandomPosition()
    {

        Vector3 spawnPos = new Vector3();
        spawnPos.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
        spawnPos.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
        spawnPos.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);
        return spawnPos;
    }
}

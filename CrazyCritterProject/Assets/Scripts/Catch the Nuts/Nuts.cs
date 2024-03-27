using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Nuts : MonoBehaviour
{
    SpawnObjects SpawnObjects;

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            SpawnObjects.objectsSpawned--;

        }
        if (collider.gameObject.CompareTag("Ground"))
        {
            Destroy (gameObject, 3.0f * Time.deltaTime);
            SpawnObjects.objectsSpawned--;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BasketballNutCollision : MonoBehaviour
{
    [SerializeField] private RandomSFXPlayer startSFX;
    [SerializeField] private RandomSFXPlayer collisionSFX;
    
    private void Start()
    {
        startSFX.PlayRandomSFX();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        collisionSFX.PlayRandomSFX();
    }
    
}

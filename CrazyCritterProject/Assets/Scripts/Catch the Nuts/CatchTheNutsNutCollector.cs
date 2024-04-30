using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTheNutsNutCollector : MonoBehaviour
{
    [SerializeField] private CatchTheNutsScoreKeeper catchTheNutsScoreKeeper;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Nuts"))
        {
            catchTheNutsScoreKeeper.AddScore();
            Destroy(collision.gameObject);
        }
    }
}

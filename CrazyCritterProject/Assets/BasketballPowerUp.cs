using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballPowerUp : MonoBehaviour
{
    public ScoreDisplay scoreDisplay;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Nuts"))
        {
            StartCoroutine(scoreDisplay.PowerUPcollected());
            gameObject.SetActive(false);
        }
    }

}

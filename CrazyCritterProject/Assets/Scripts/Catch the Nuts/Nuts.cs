using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerEnterScript : MonoBehaviour
{
    public TMP_Text scoreText;

    public string targetTag = "Pickup";

    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            score++;

            scoreText.text = score.ToString();

            transform.position = Newspawner.Instance.GetRandomPosition();
        }
        else
        {
            transform.position = Newspawner.Instance.GetRandomPosition();
        }
    }
}
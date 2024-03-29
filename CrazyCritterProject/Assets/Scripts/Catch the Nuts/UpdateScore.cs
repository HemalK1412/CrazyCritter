using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    public TextMeshProUGUI text;
    int score;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Nuts"))
        {
            score++;
            text.text = score.ToString();
            Destroy(collision.gameObject);
        }
    }
}

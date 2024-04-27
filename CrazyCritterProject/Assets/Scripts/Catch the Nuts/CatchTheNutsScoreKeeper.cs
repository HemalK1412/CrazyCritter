using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatchTheNutsScoreKeeper : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int score;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Nuts"))
        {
            score++;
            text.text = "Score: " + score.ToString();
            Destroy(collision.gameObject);
        }
    }
}

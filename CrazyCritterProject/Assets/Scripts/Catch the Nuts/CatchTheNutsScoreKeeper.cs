using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatchTheNutsScoreKeeper : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int score;

    public void AddScore()
    {
        score++;
        text.text = "Score: " + score.ToString();
    }
}

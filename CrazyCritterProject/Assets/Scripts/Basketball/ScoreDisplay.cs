using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreDisplay : MonoBehaviour 
{
	ScoreKeeper scoreKeeper;
    public TextMeshProUGUI ScoreHUD;

	void Start ()
	{
		scoreKeeper = FindObjectOfType<ScoreKeeper>();
	}
	
	void Update ()
	{
		ScoreHUD.text = "Score: " + scoreKeeper.score.ToString();
	}
}

using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreDisplay : MonoBehaviour 
{
    public TextMeshProUGUI ScoreHUD;
	public int Score = 0;

	void Start ()
	{
	}
	
	void Update ()
	{
		ScoreHUD.text = "Score: " + Score.ToString();
	}

	
}

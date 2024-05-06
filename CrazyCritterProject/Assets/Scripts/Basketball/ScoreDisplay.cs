 using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreDisplay : MonoBehaviour 
{
    public TextMeshProUGUI ScoreHUD;
	public TextMeshProUGUI comboCountHUD;

	public int Score = 0;

	public int ScorePerCombo;
	public int ComboCount;



	public void IncreaseScore()
	{
		Score = Score + 50;
		
		/* The section is for the combo version of the game.
		ComboCount++;
        
		if(ComboCount >= ScorePerCombo)
		{
			Score += ScorePerCombo;
		}
        
		comboCountHUD.text = ComboCount.ToString();
		*/


        ScoreHUD.text = "Score: " + Score.ToString();

    }

	/*
    public void ResetCombo()
    {
		Score = Score + ComboCount;
		ScoreHUD.text = "Score: " + Score.ToString();
		ComboCount = 0;
        comboCountHUD.text = ComboCount.ToString();
    }
	*/
}

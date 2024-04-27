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
		Score = Score++;
		ComboCount++;

		if(ComboCount >= ScorePerCombo)
		{
			Score += ScorePerCombo;
			ComboCount = 0;
		}

        ScoreHUD.text = "Score: " + Score.ToString();
		comboCountHUD.text = ComboCount.ToString();

    }


    public void ResetCombo()
    {
		ComboCount = 0;
        comboCountHUD.text = ComboCount.ToString();
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenUI : MonoBehaviour
{
    [SerializeField] Button Save;
    [SerializeField] Button Load;

    [SerializeField] Button Play;
    [SerializeField] Button Quit;

    SaveManager SaveManager;
    Stats Stats;


    // For Debug Purpose

    public TMP_Text DayCount;
    public TMP_Text NutCount;
    public TMP_Text Position;
    public TMP_Text SpeedPowerUP;



    private void Awake()
    {
        //SaveManager.Load();
        DayCount.text = ("DayCount : " + Stats.DayCount);
        NutCount.text = ("NutCount : " + Stats.Nuts);
        Position.text = ("Position : " + Stats.p_Position.x + "," + Stats.p_Position.y + "," + Stats.p_Position.z);

    }

    // Debug End



    public void SaveButtonPressed()
    {
       SaveManager.Save();
    }
    public void LoadButtonPressed()
    {
        SaveManager.Load();
    }


    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("Casino");
    }

    public void QuitButtonPressed() 
    {
        Application.Quit();
    }

}

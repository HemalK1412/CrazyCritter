using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenUI : MonoBehaviour
{

    [SerializeField] Button SettingsBack;
    [SerializeField] Button SaveSettings;

    public Canvas TitleScreen;
    public Canvas SettingsCanvas;

    [SerializeField]SaveManager SaveManager;

    /* For Debug Purpose

    public TMP_Text DayCount;
    public TMP_Text NutCount;
    public TMP_Text Position;
    public TMP_Text SpeedPowerUP;



    /*private void Awake()
    {
        //SaveManager.Load();
        DayCount.text = ("DayCount : " + Stats.DayCount);
        NutCount.text = ("NutCount : " + Stats.Nuts);
        Position.text = ("Position : " + Stats.p_Position.x + "," + Stats.p_Position.y + "," + Stats.p_Position.z);

    }

    Debug End
    */

    public void PlayButtonPressed()
    {

        if (!PlayerPrefs.HasKey("NewGame"))
        {
            DataBank.Instance.MyStats.DayCount = 1;
            int initialcurrency = PlayerPrefs.GetInt("InitialCurrency");
            DataBank.Instance.MyStats.Nuts = initialcurrency;
        }
        SaveManager.Save();

        PlayerPrefs.SetInt("NewGame", 1);
        SceneManager.LoadScene("Casino");

    }


    public void QuitButtonPressed() 
    {
        Application.Quit();
    }

    public void SettingsButtonPressed()
    {
        SettingsCanvas.gameObject.SetActive(true);
        TitleScreen.gameObject.SetActive(false);
    }

    public void SettingsBackPressed()
    {
        SettingsCanvas.gameObject.SetActive(false);
        TitleScreen.gameObject.SetActive(true);
    }

    public void SaveButtonPressed()
    {
        SaveManager.Save();
    }

    public void DeleteSavePressed()
    {
        SaveManager.WipeSaves();
        PlayerPrefs.DeleteAll();
    }


}

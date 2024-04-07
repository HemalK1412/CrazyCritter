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

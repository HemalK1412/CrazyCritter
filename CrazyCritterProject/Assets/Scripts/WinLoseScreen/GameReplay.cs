using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameReplay : MonoBehaviour
{
    public GameObject WinCondition;
    public GameObject LoseCondition;

    public VideoPlayer VideoPlayer;
    public VideoClip WinClip;
    public VideoClip LoseClip;

    public SaveManager saveManager;
    [SerializeField] ColorBlindFilter colorBlindFilter;

    public void Awake()
    {
        ColorBlindMode mode = (ColorBlindMode)DataBank.Instance.MyStats.ColorBlindEnum;
        colorBlindFilter.mode = mode;
        //DataBank.Instance.MyStats.ColorBlindEnum = (int)colorBlindFilter.mode;
        if (DataBank.Instance.MyStats.Nuts >= PlayerPrefs.GetInt("TargetScore"))
        {
            WinCondition.SetActive(true);
            VideoPlayer.clip = WinClip;
        }
        else
        {
            LoseCondition.SetActive(true);
            VideoPlayer.clip = LoseClip;
        }
    }

    public void ReplayButtonPresesed()
    {
        saveManager.WipeSaves();

        DataBank.Instance.MyStats = new Stats();

        PlayerPrefs.SetInt("InitialCurrency", 500);
        PlayerPrefs.SetInt("TargetScore", 1000);

        PlayerPrefs.DeleteKey("NewGame");
        //Remove key to assign initial currency in databank.
        SceneManager.LoadScene("StartScreen");
    }
}

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


    public TextMeshProUGUI dayCountText;
    public TextMeshProUGUI nutCountText;
    public TextMeshProUGUI mouseSensText;

    public TextMeshProUGUI Datapath;

    public TextMeshProUGUI saveddayCountText;
    public TextMeshProUGUI savednutCountText;
    public TextMeshProUGUI savedmouseSensText;


    public int DayCount;
    public int NutCount;
    public float MouseSens;

    DataBank DataBank;

    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("Casino");
    }

    public void QuitButtonPressed() 
    {
        Application.Quit();
    }
    private void Awake()
    {
        DataBank = FindAnyObjectByType<DataBank>();
        LoadValues();
    }

    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.R))
        {
            RandomValues();
        }
        if ( Input.GetKeyDown(KeyCode.L))
        {
            DataBank.MyStats.DayCount = DayCount;
            DataBank.MyStats.Nuts = NutCount;
            DataBank.MyStats.mouse_Sens = MouseSens;
        }

        dayCountText.text = ("DayCount :" + DayCount.ToString());
        nutCountText.text = ("NUTCount :" + NutCount.ToString());
        mouseSensText.text = ("MouseSens = " + MouseSens.ToString());

        saveddayCountText.text = ("dataBank daycount :" + DataBank.MyStats.DayCount.ToString());
        savednutCountText.text = ("dataBank nutCount :" + DataBank.MyStats.Nuts.ToString());
        savedmouseSensText.text = ("dataBank MouseSens :" + DataBank.MyStats.mouse_Sens.ToString());



        Datapath.text = (Application.persistentDataPath);
    }

    public void RandomValues()
    {
        DayCount = Random.Range (0, 100);
        NutCount = Random.Range(0, 100);
        MouseSens = Random.Range(0, 100);
    }

    public void LoadValues()
    {
        DayCount = DataBank.MyStats.DayCount;
        NutCount = DataBank.MyStats.Nuts;
        MouseSens = DataBank.MyStats.mouse_Sens;
    }
}

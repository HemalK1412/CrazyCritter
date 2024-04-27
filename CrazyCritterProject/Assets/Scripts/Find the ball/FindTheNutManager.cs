using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FindTheNutManager : MonoBehaviour
{
    [SerializeField] GameObject[] transforms;
    public GameObject[] cups;
    public GameObject Player;

    public int Score = 10;

    public Canvas FindTheNutMiniGameStartCanvas;
    public Canvas FindTheNutMiniGameHUD;
    public Canvas FindTheNutMiniGameEndCanvas;

    public TextMeshProUGUI EndScore;

    [SerializeField] NutParent nutParent;
    [SerializeField] Shuffle shuffle;
    [SerializeField] Selection selection;
    [SerializeField] DataBank dataBank;



    
    private void Awake()
    {
        dataBank = GameObject.Find("DataBank").GetComponent<DataBank>();

        FindTheNutMiniGameStartCanvas.gameObject.SetActive(true);

        Player.GetComponent<Selection>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    void Start()
    {


    }
  


    public void MiniGameStartButtonPressed()
    {
        StartCoroutine(GetToPositions());
        FindTheNutMiniGameStartCanvas.gameObject.SetActive(false);
    }


    public void MiniGameEnd()
    {
        Score = Score * dataBank.MyStats.DayCount;
        FindTheNutMiniGameHUD.gameObject.SetActive(false);
        FindTheNutMiniGameEndCanvas.gameObject.SetActive(true);
        if (selection.NutFound == true)
        {
            EndScore.text = "You have been rewwarded = " + Score.ToString() + "Nuts";
            dataBank.MyStats.Nuts = dataBank.MyStats.Nuts + Score;
        }
        else
        {
            EndScore.text = "You Lost";
        }
    }

    public void MiniGameEndContinuePressed()
    {
        dataBank.MyStats.DayCount = dataBank.MyStats.DayCount + 1;
        SceneManager.LoadScene("Casino");
    }

    IEnumerator GetToPositions()
    {

        float t = 0;

        while (t <= 1)
        {
            t += Time.deltaTime;
            for (int i = 0; i < cups.Length; i++)
            {
                cups[i].transform.position = Vector3.Lerp(cups[i].transform.position, transforms[i].transform.position, t);
            }
            yield return null;
        }

        nutParent.ParentToCup();
        StartCoroutine(shuffle.BaseShuffle(dataBank.MyStats.DayCount));
        Player.GetComponent<Selection>().enabled = true;
    }
}

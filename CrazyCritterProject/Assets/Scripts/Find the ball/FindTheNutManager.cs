using System.Collections;
using System.Runtime.InteropServices;
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

    [SerializeField] SaveManager saveManager;
    [SerializeField] NutParent nutParent;
    [SerializeField] Shuffle shuffle;
    [SerializeField] Selection selection;
    [SerializeField] ColorBlindFilter colorBlindFilter;

    private void Awake()
    {
        ColorBlindMode mode = (ColorBlindMode)DataBank.Instance.MyStats.ColorBlindEnum;
        colorBlindFilter.mode = mode;
        //DataBank.Instance.MyStats.ColorBlindEnum = (int)colorBlindFilter.mode;
        FindTheNutMiniGameStartCanvas.gameObject.SetActive(true);

        Player.GetComponent<Selection>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void MiniGameStartButtonPressed()
    {
        StartCoroutine(GetToPositions());
        FindTheNutMiniGameStartCanvas.gameObject.SetActive(false);
    }


    public void MiniGameEnd()
    {
        Score = DataBank.Instance != null ? Score * DataBank.Instance.MyStats.DayCount * Score : Score;
        FindTheNutMiniGameHUD.gameObject.SetActive(false);
        FindTheNutMiniGameEndCanvas.gameObject.SetActive(true);
        if (selection.NutFound == true)
        {
            EndScore.color = Color.green;
            EndScore.text = $"You found it! Take 150 of my nuts :)";
        }
        else
        {
            EndScore.color = Color.red;
            EndScore.text = "You Lost 100 Nuts.";
        }
    }

    public void MiniGameEndContinuePressed()
    {
        if (selection.NutFound == true)
        {
            DataBank.Instance.MyStats.Nuts += 150;

        }
        else
        {
            DataBank.Instance.MyStats.Nuts -= 100;
        }

        DataBank.Instance.MyStats.DayCount++;
        saveManager.Save();
        SceneManager.LoadScene("Casino");
    }

    IEnumerator GetToPositions()
    {
        yield return new WaitForSeconds(1.5f);

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
        StartCoroutine(shuffle.BaseShuffle(DataBank.Instance != null ? DataBank.Instance.MyStats.DayCount : 1));
    }
}

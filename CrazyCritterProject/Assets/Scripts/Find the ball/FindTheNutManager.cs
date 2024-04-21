using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FindTheNutManager : MonoBehaviour
{
    [SerializeField] GameObject[] transforms;
    public GameObject[] cups;
    public GameObject Player;

    public int GameStage = 0;

    public int BaseShuffleMultiplier = 1;

    public Canvas FindTheNutMiniGameStartCanvas;
    public Canvas FindTheNutMiniGameHUD;
    public Canvas FindTheNutMiniGameEndCanvas;

    [SerializeField] float lerpmultiplier = 0.7f;


    GameManager gameManager;
    SaveManager saveManager;
    NutParent nutParent;
    Shuffle shuffle;
    Selection selection;

    private void Awake()
    {
        

        FindTheNutMiniGameHUD.gameObject.SetActive(false);
        FindTheNutMiniGameStartCanvas.gameObject.SetActive(true);
        FindTheNutMiniGameEndCanvas.gameObject.SetActive(false);

        Player.GetComponent<Selection>().enabled = false;

        if (gameManager == null) return;
        BaseShuffleMultiplier = gameManager.gm_DayoftheWeek;
    }

    void Start()
    {


    }
    
    void Update()
    {
        if(GameStage == 1)
        {
            StartCoroutine(GetToPositions());
        }
        if (GameStage == 2)
        {
            nutParent.ParentToCup();
            StartCoroutine(shuffle.BaseShuffle(BaseShuffleMultiplier));
            Player.GetComponent<Selection>().enabled = true;
        }
        if (GameStage == 3)
        {
            if (selection.NutFound)
            {
                //Game Manager score update
                //Some sort of Nut Found panel or changes to the end screen.
                MiniGameEnd();
            }
            else
            {
                MiniGameEnd();
            }
        }
    }

    public void MiniGameStartButtonPressed()
    {
        FindTheNutMiniGameStartCanvas.gameObject.SetActive(false);
        FindTheNutMiniGameHUD.gameObject.SetActive(true);
        GameStage = 1;
    }

    public void MiniGameEnd()
    {
        FindTheNutMiniGameHUD.gameObject.SetActive(false);
        FindTheNutMiniGameEndCanvas.gameObject.SetActive(true);
    }

    public void MiniGameEndContinuePressed()
    {
        //Save the score
        saveManager.Save();

        SceneManager.LoadScene("Casino");
    }

    IEnumerator GetToPositions()
    {
        for (int i = 0; i < cups.Length; i++)
        {
            cups[i].transform.position = Vector3.Lerp(cups[i].transform.position, transforms[i].transform.position, lerpmultiplier * Time.deltaTime);
        }
        GameStage = 2;
        yield return null;
    }
}

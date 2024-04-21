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


    GameManager gameManager;
    SaveManager saveManager;
    [SerializeField] NutParent nutParent;
    [SerializeField] Shuffle shuffle;
    [SerializeField] Selection selection;
    
    private void Awake()
    {
        FindTheNutMiniGameStartCanvas.gameObject.SetActive(true);

        Player.GetComponent<Selection>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        if (gameManager == null) return;
        BaseShuffleMultiplier = gameManager.gm_DayoftheWeek;
    }

    void Start()
    {


    }
  
    //Game Manager score update
    //Some sort of Nut Found panel or changes to the end screen. //Create text field


    public void MiniGameStartButtonPressed()
    {
        StartCoroutine(GetToPositions());
        FindTheNutMiniGameStartCanvas.gameObject.SetActive(false);
    }



    public void MiniGameEndContinuePressed()
    {
        //Save the score
        //saveManager.Save();

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
        StartCoroutine(shuffle.BaseShuffle(BaseShuffleMultiplier));
        Player.GetComponent<Selection>().enabled = true;
    }
}

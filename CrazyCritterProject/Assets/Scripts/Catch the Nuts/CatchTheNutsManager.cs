using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CatchTheNutsManager : MonoBehaviour
{
    public Canvas MiniGameStartCanvas;
    public Canvas MiniGameHUD;
    public Canvas MiniGameEndCanvas;

    public GameObject p_player;
    public Rigidbody p_Rigidbody;

    public GameObject MG_Spawner;
    public GameObject MG_Destroyer;
    public GameObject Timer;

    public TextMeshProUGUI EndScreenScore;

    [SerializeField] MiniGamestimer miniGamestimer;
    [SerializeField] CatchTheNutsScoreKeeper catchTheNutsScoreKeeper;

    [SerializeField] DataBank dataBank;

    

    void Awake()
    {
        dataBank = GameObject.Find("DataBank").GetComponent<DataBank>();

        MiniGameHUD.gameObject.SetActive(false);
        MiniGameStartCanvas.gameObject.SetActive(true);
        MiniGameEndCanvas.gameObject.SetActive(false);

        MG_Spawner.SetActive(false);
        MG_Destroyer.SetActive(true);
        
        Cursor.lockState = CursorLockMode.None;

        p_player = GameObject.FindGameObjectWithTag("Player");
        if (p_player == null) return;
        p_Rigidbody = p_player.GetComponent<Rigidbody>();
        p_Rigidbody.isKinematic = false;
    }

    private void FixedUpdate()
    {
        if(miniGamestimer.remainingTime <= 0)
        {
            Debug.Log("Time Skipped");
            MiniGameEnd();
        }
    }


    public void MiniGameStartButtonPressed()
    {
        MiniGameStartCanvas.gameObject.SetActive(false);
        MiniGameHUD.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;

        p_Rigidbody.isKinematic = true;
        MG_Spawner.SetActive(true);
        MG_Destroyer.SetActive(true);
    }

    public void MiniGameEnd()
    {
        MG_Destroyer.SetActive(false);
        MG_Spawner.SetActive(false);
        
        Cursor.lockState = CursorLockMode.None;
        
        p_Rigidbody.isKinematic = false;

        MiniGameHUD.gameObject.SetActive(false);
        MiniGameEndCanvas.gameObject.SetActive(true);

        EndScreenScore.text = "Nuts Gathered = " + catchTheNutsScoreKeeper.score.ToString();


    }

    public void MiniGameEndContinuePressed()
    {
        dataBank.MyStats.Nuts = dataBank.MyStats.Nuts + catchTheNutsScoreKeeper.score;
        dataBank.MyStats.DayCount = dataBank.MyStats.DayCount + 1;
        SceneManager.LoadScene("Casino");
    }
}

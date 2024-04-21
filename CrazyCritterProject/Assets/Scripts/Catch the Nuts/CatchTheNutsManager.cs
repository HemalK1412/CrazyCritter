using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    MiniGamestimer miniGamestimer;
    NutParent NutParent;
    SaveManager saveManager;
    

    void Awake()
    {
        miniGamestimer = FindAnyObjectByType<MiniGamestimer>();

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

        p_Rigidbody.isKinematic = false;

        MiniGameHUD.gameObject.SetActive(false);
        MiniGameEndCanvas.gameObject.SetActive(true);

        //get the score to the Game manager and save it.
    }

    public void MiniGameEndContinuePressed()
    {
        //saveManager.Save();
        SceneManager.LoadScene("Casino");
    }
}

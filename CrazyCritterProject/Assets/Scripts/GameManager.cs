using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject p_Player;
    public Rigidbody p_Rigidbody;


    public Canvas PauseCanvas;
    public Canvas HUD;

    public bool PauseGameOnStart = true;
    public bool isPaused;

    public GameObject GunPickup;
    public GameObject HatPickup;
    public Transform GunPickUpLocation;
    public Transform HatPickupLocation;

    public int TargetScore = 1000; //To be confirmed

    private void Awake()
    {
        if (DataBank.Instance == null || DataBank.Instance.MyStats.GunPickup == false)
        {
            if(GunPickup!=null)
                GunPickup.transform.position = GunPickUpLocation.transform.position;
        }
        else
        {
            Destroy(GunPickup);
        }

        if (DataBank.Instance == null || DataBank.Instance.MyStats.HatPickup == false)
        {
            if(HatPickup!=null)
                HatPickup.transform.position = HatPickupLocation.transform.position;
        }
        else
        {
            Destroy(HatPickup);
        }

        if(DataBank.Instance.MyStats.DayCount == 7)
        {
            SceneManager.LoadScene("WinLose");
            // Nut Calculation is in The Win Lose scene
            // Background check the value in Awake()
        }
    }


    public void Start()
    {
        /*
        if (PauseCanvas == null) return;
        if (PauseGameOnStart)
        {
            PauseCanvas.gameObject.SetActive(false);
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
        */
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseCanvas == null) return;
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (p_Rigidbody == null) return;
        isPaused = true;

        PauseCanvas.gameObject.SetActive(true);

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        if (p_Rigidbody == null) return;
        
        isPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

}

